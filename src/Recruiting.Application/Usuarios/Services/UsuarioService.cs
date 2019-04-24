using Recruiting.Application.Dashboard.Enums;
using Recruiting.Application.Usuarios.Mappers;
using Recruiting.Application.Usuarios.Messages;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruiting.Application.Usuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Fields

        private readonly IUsuarioRepository _usuarioRepository;

        #endregion

        #region Constructors

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        #region IUsuarioService Members

        public GetUsuariosResponse GetUsuarios(DataTableRequest request)
        {
            var response = new GetUsuariosResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, UsuarioMapper.GetPropertiePath);

                response.UsuarioViewModel = filtered.ConvertToUsuarioViewModel();
                response.TotalElementos = query.Count();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuariosResponse GetUsuariosByCentroUsuarioId(int CentroUsuarioId)
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();
            request.CustomFilters.Add("CentroUsuarioId", CentroUsuarioId.ToString());

            return GetUsuarios(request);

        }

        public GetUsuariosResponse GetUsuarios()
        {
            var response = new GetUsuariosResponse();

            try
            {
                response.UsuarioViewModel = UsuarioMapper.ConvertToUsuarioViewModel(_usuarioRepository.GetByCriteria(x => x.IsActivo));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuarioByIdResponse GetUsuarioById(int usuarioId)
        {
            var response = new GetUsuarioByIdResponse();

            try
            {
                var usuario = _usuarioRepository.GetOne(x => x.UsuarioId == usuarioId && x.IsActivo);

                var usuarioViewModel = usuario.ConvertToCreateEditUsuarioViewModel();

                response.UsuarioViewModel = usuarioViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuarioByUserNameResponse GetUsuarioByUserName(string userName)
        {
            var response = new GetUsuarioByUserNameResponse();

            try
            {
                var usuario = _usuarioRepository.GetOne(x => x.UserName == userName && x.IsActivo);

                var usuarioViewModel = usuario.ConvertToCreateEditUsuarioViewModel();

                response.UsuarioViewModel = usuarioViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }     

        public GetUsuariosByNombreUsuarioResponse GetUsuariosByNombreUsuario(string textSearch)
        {
            var response = new GetUsuariosByNombreUsuarioResponse() { IsValid = true };

            try
            {
                var listaUsuarios = _usuarioRepository.GetByCriteria(x => x.IsActivo);
                response.Usuarios = listaUsuarios.ConvertToUsuarioViewModel().ToList();
                response.Usuarios = from usu in response.Usuarios
                                    where usu.Usuario.RemoveDiacritics().ToLower().Contains(textSearch.RemoveDiacritics().ToLower())
                                    select usu;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuariosEntrevistadoresByNombreUsuarioYCentroResponse GetUsuariosEntrevistadoresByNombreUsuarioYCentro(string textSearch)
        {
            var response = new GetUsuariosEntrevistadoresByNombreUsuarioYCentroResponse() { IsValid = true };

            try
            {

                int? centro = null;

                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                    if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                    {
                        centro = UsuarioRolPermisoViewModel.CentroIdUsuario;
                    }
                }

                var listaUsuarios = _usuarioRepository.GetByCriteria(x => x.IsActivo && x.UsuarioRol.Any(y => y.RolId == (int)TipoRolUsuario.Entrevistador));

                if (centro.HasValue)
                {
                    listaUsuarios = listaUsuarios.Where(x => x.CentroId == centro.Value);
                }

                response.Usuarios = listaUsuarios.ConvertToUsuarioViewModel().ToList();

                response.Usuarios = from usu in response.Usuarios
                                    where usu.Usuario.RemoveDiacritics().ToLower().Contains(textSearch.RemoveDiacritics().ToLower())
                                select usu;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SearchUserNameUsadoResponse SearchUserNameUsado(int idUsuario, string userName)
        {
            var response = new SearchUserNameUsadoResponse();

            try
            {
                var usuarioConUserName = _usuarioRepository.Find(x => x.IsActivo && x.UserName == userName);
                if (usuarioConUserName == null)
                {
                    response.Usado = false;
                }
                else
                {
                    if(usuarioConUserName.UsuarioId == idUsuario)
                    {
                        response.Usado = false;
                    }
                    else
                    {
                        response.Usado = true;
                    }
                }
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveUsuarioResponse SaveUsuario(CreateEditUsuarioViewModel usuarioViewModel)
        {
            var response = new SaveUsuarioResponse();

            try
            {
                if (usuarioViewModel.UsuarioId == 0)
                {
                    var newUsuario = Save(usuarioViewModel);
                    if (newUsuario != null)
                    {
                        response.IsValid = true;
                        response.UsuarioId = newUsuario.UsuarioId;
                        response.ErrorMessage = "Usuario Guardado Correctamente";
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save Usuario";
                    }
                }
                else
                {
                    if (Update(usuarioViewModel) > 0)
                    {
                        response.IsValid = true;
                        response.UsuarioId = usuarioViewModel.UsuarioId;
                        response.ErrorMessage = "Usuario Guardado Correctamente";
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DeleteUsuarioResponse DeleteUsuario(int usuarioId)
        {
            var response = new DeleteUsuarioResponse();

            try
            {
                var usuario = _usuarioRepository.GetOne(x => x.UsuarioId == usuarioId);

                usuario.IsActivo = false;
                usuario.UsuarioRol.Clear();

                if (_usuarioRepository.Update(usuario) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to delete Usuario";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuarioRolPermisoResponse GetUsuarioRolPermisoByUserName(string userName)
        {
            var response = new GetUsuarioRolPermisoResponse();

            try
            {
                var usuario = _usuarioRepository.GetOne(x => x.UserName == userName && x.IsActivo);

                var usuarioRolPermisoViewModel = usuario.ConvertToUsuarioRolPermisoViewModel();

                response.UsuarioRolPermisoViewModel = usuarioRolPermisoViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetUsuarioByEmailResponse GetUsuarioByEmail(string email)
        {
            var response = new GetUsuarioByEmailResponse();

            try
            {
                var usuario = _usuarioRepository.GetOne(x => x.Email == email && x.IsActivo);

                var usuarioViewModel = usuario.ConvertToCreateEditUsuarioViewModel();

                response.UsuarioViewModel = usuarioViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        #endregion

        #region Private Methods

        private Usuario Save(CreateEditUsuarioViewModel createEditUsuarioViewModel)
        {
            var usuario = new Usuario();

            usuario.UpdateUsuario(createEditUsuarioViewModel);

            var newUsuario = _usuarioRepository.Create(usuario);

            return newUsuario;
        }

        private int Update(CreateEditUsuarioViewModel createEditUsuarioViewModel)
        {
            var usuario = _usuarioRepository.GetOne(x => x.UsuarioId == createEditUsuarioViewModel.UsuarioId);

            usuario.UsuarioRol.Clear();

            usuario.UpdateUsuario(createEditUsuarioViewModel);

            return _usuarioRepository.Update(usuario);
        }

        private IQueryable<Usuario> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _usuarioRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Usuario") && (customFilter["Usuario"] != string.Empty))
            {
                    var nombre = customFilter["Usuario"];
                    query = query.Where(x => x.Nombre.Contains(nombre));
            }

            if (customFilter.ContainsKey("Rol") && (customFilter["Rol"] != string.Empty))
            {
                    var rol = customFilter["Rol"];
                    query = query.Where(x => x.UsuarioRol.Select(y => y.RolId.ToString()).Contains(rol));
            }
            
            if (customFilter.ContainsKey("CentroSearch") && (customFilter["CentroSearch"] != string.Empty))
            {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                    query = query.Where(x => x.CentroId == CentroUsuarioId);
            }

                return query;
        }
        #endregion


        

      


    }
}
