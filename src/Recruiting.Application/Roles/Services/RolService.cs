using Recruiting.Application.Roles.Mappers;
using Recruiting.Application.Roles.Messages;
using Recruiting.Application.Roles.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Recruiting.Application.Roles.Services
{
    public class RolService : RoleProvider, IRolService
    {
        #region Fields

        private readonly IRolRepository _rolRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        #endregion

        #region Constructors

        public RolService()
        {
            _rolRepository = new RolRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        public RolService(IRolRepository rolRepository, IUsuarioRepository usuarioRepository)
        {
            _rolRepository = rolRepository;
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        #region IRolService Members

        public GetRolesResponse GetRoles(DataTableRequest request)
        {
            var response = new GetRolesResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, RolMapper.GetPropertiePath);

                response.RolViewModel = filtered.ConvertToRolViewModel();
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

        public GetRolesResponse GetRoles()
        {
            var response = new GetRolesResponse();

            try
            {
                response.RolViewModel = RolMapper.ConvertToRolViewModel(_rolRepository.GetByCriteria(x => x.IsActivo));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetRolByIdResponse GetRolById(int rolId)
        {
            var response = new GetRolByIdResponse();

            try
            {
                var rol = _rolRepository.GetOne(x => x.RolId == rolId);

                var rolViewModel = rol.ConvertToCreateEditRolViewModel();

                response.RolViewModel = rolViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveRolResponse SaveRol(CreateEditRolViewModel rolViewModel)
        {
            var response = new SaveRolResponse();

            try
            {
                if (rolViewModel.RolId == 0)
                {
                    var newRol = Save(rolViewModel);
                    if (newRol != null)
                    {
                        response.IsValid = true;
                        response.RolId = newRol.RolId;
                        response.ErrorMessage = "Rol Guardado Correctamente";
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save Rol";
                    }
                }
                else
                {
                    if (Update(rolViewModel) > 0)
                    {
                        response.IsValid = true;
                        response.RolId = rolViewModel.RolId;
                        response.ErrorMessage = "Rol Guardado Correctamente";
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Rol";
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

        public DeleteRolResponse DeleteRol(int rolId)
        {
            var response = new DeleteRolResponse();

            try
            {
                var rol = _rolRepository.GetOne(x => x.RolId == rolId);

                rol.IsActivo = false;
                rol.UsuarioRol.Clear();

                if (_rolRepository.Update(rol) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to delete Rol";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        #endregion

        #region RoleProvider
        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _usuarioRepository.GetOne(u => u.Nombre == username);
            if (user == null)
                return false;
            return user.UsuarioRol != null && user.UsuarioRol.Select(
                    u => u.Rol).Any(r => r.Nombre == roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            var user = _usuarioRepository.GetOne(u => u.UserName == username);
            if (user == null)
                return new string[] { };
            return user.UsuarioRol == null ? new string[] { } :
                user.UsuarioRol.Select(u => u.Rol).Select(u => u.Nombre).ToArray();
        }

        public override string[] GetAllRoles()
        {
            return _rolRepository.GetByCriteria(x => x.IsActivo).Select(r => r.Nombre).ToArray();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames) { }
        public override void CreateRole(string roleName) { }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) { return true; }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch) { return new string[0]; }
        public override string[] GetUsersInRole(string roleName) { return new string[0]; }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) { }
        public override bool RoleExists(string roleName) { return true; }
        public override string ApplicationName { get; set; }
        #endregion RoleProvider

        #region Private Methods

        private Rol Save(CreateEditRolViewModel createEditRolViewModel)
        {
            var rol = new Rol();

            rol.UpdateRol(createEditRolViewModel);

            var newRol = _rolRepository.Create(rol);

            return newRol;
        }

        private int Update(CreateEditRolViewModel createEditRolViewModel)
        {
            var rol = _rolRepository.GetOne(x => x.RolId == createEditRolViewModel.RolId);

            rol.PermisoRol.Clear();

            rol.UpdateRol(createEditRolViewModel);

            return _rolRepository.Update(rol);
        }

        private IQueryable<Rol> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _rolRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Permiso") && (customFilter["Permiso"] != string.Empty))
            {
                    var permiso = customFilter["Permiso"];
                    query = query.Where(x => x.PermisoRol.Select(y => y.PermisoId.ToString()).Contains(permiso));
            }

            if (customFilter.ContainsKey("Nombre") && (customFilter["Nombre"] != string.Empty))
            {
                    var nombre = customFilter["Nombre"];
                    query = query.Where(x => x.Nombre.Contains(nombre));
            }

            return query;
        }
        #endregion
    }
}
