using Recruiting.Application.Proyectos.Mappers;
using Recruiting.Application.Proyectos.Messages;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Recruiting.Application.Proyectos.Services
{
    public class ProyectoService : IProyectoService
    {
        #region Fields

        private readonly IProyectoRepository _proyectoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly INecesidadRepository _necesidadRepository;

        #endregion

        #region Constructors

        public ProyectoService(IProyectoRepository proyectoRepository,
                               IClienteRepository clienteRepository)
        {
            _proyectoRepository = proyectoRepository;
            _clienteRepository = clienteRepository;
            _necesidadRepository = new NecesidadRepository();
        }

        #endregion

        #region IProyectoService Members

        public GetProyectoResponse GetProyecto(int proyectoId)
        {
            var response = new GetProyectoResponse() { IsValid = true };

            try
            {
                var proyecto = _proyectoRepository.GetOne(x => x.ProyectoId == proyectoId);
                if (proyecto != null)
                {
                    response.Proyecto = proyecto.ConvertToProyectoRowViewModel(null);
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

        public GetProyectosResponse GetProyectos()
        {
            var response = new GetProyectosResponse();

            try
            {
                response.ProyectoViewModel = ProyectoMapper.ConvertToProyectoViewModel(_proyectoRepository.GetByCriteria(x => x.IsActivo), null);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetProyectosNombreIdResponse GetProyectosNombreId()
        {
            var response = new GetProyectosNombreIdResponse();

            int CentroUsuarioId = 0;

            //filtro por el centro del usuario
            if (HttpContext.Current.Session["Usuario"] != null)
            {

                var UsuarioRolPermisoViewModel = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                if (UsuarioRolPermisoViewModel.CentroIdUsuario != null)
                {
                    CentroUsuarioId = Convert.ToInt16(HttpContext.Current.Session["CentroIdUsuario"]);
                }
            }

            try
            {
                var listaProyectos = _proyectoRepository.GetByCriteria(x => x.IsActivo &&
                                            (!(CentroUsuarioId != 0 && x.CentroId.HasValue) || x.CentroId == CentroUsuarioId));
                listaProyectos.OrderBy(x => x.Nombre);
                response.ProyectoViewModel = ProyectoMapper.ConvertToProyectoNombreIdViewModel(listaProyectos);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetProyectosResponse GetProyectos(DataTableRequest request)
        {
            var response = new GetProyectosResponse() { IsValid = true };

            try
            {
                //filtro por el centro del usuario
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    var permisosUsuario = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                    if (permisosUsuario.CentroIdUsuario.HasValue)
                    {
                        if (request.CustomFilters.ContainsKey("CentroId"))
                        {
                            request.CustomFilters["CentroId"] = permisosUsuario.CentroIdUsuario.Value.ToString();
                        }
                        else
                        {
                            request.CustomFilters.Add("CentroId", permisosUsuario.CentroIdUsuario.Value.ToString());
                        }
                    }
                }

                //establecer los filtros
                var query = Filter(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, ProyectoMapper.GetPropertiePath);

                var clienteIds = filtered.Select(x => x.ClienteId).ToList();
                var nombreClientes = _clienteRepository.GetByCriteria(x => clienteIds.Contains(x.ClienteId)).ToDictionary(x => x.ClienteId, x => x.Nombre);

                response.ProyectoViewModel = filtered.ConvertToProyectoViewModel(nombreClientes);
                response.TotalElementos = query.Count();
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetProyectosByClienteResponse GetProyectosByCliente(int? clienteId)
        {
            var response = new GetProyectosByClienteResponse();
            try
            {
                if (clienteId.HasValue) // tem valor devolve os projectos desse cliente
                {
                    int CentroUsuarioId = HttpContext.Current.Session["CentroIdUsuario"] != null ? Convert.ToInt16(HttpContext.Current.Session["CentroIdUsuario"]) : 0;

                    response.ProyectoViewModel = ProyectoMapper.ConvertToProyectoViewModel(_proyectoRepository.GetByCriteria(x => x.ClienteId == clienteId.Value 
                                                                                            &&  x.CentroId == CentroUsuarioId && x.IsActivo).OrderBy(x => x.Nombre), null);
                }
                else // não tem valor tem que procurar por centro atraves do usuario que esta logado
                {
                    int CentroUsuarioId = 0;
                    //filtro por el centro del usuario
                    if (HttpContext.Current.Session["Usuario"] != null)
                    {
                        CentroUsuarioId = Convert.ToInt16(HttpContext.Current.Session["CentroIdUsuario"]);

                    }
                    response.ProyectoViewModel = ProyectoMapper.ConvertToProyectoViewModel(_proyectoRepository.GetByCriteria(x => x.IsActivo &&
                                            ((CentroUsuarioId == 0) || x.CentroId == CentroUsuarioId)).OrderBy(x => x.Nombre), null);
                        
                    response.IsValid = true;
                }
            }

            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
        

        public SaveProyectoResponse SaveProyecto(ProyectoRowViewModel model)
        {
            var response = new SaveProyectoResponse() { IsValid = true, ErrorMessage = "Proyecto guardado correctamente." };

            try
            {
                var proyecto = _proyectoRepository.GetOne(x => x.ProyectoId == model.ProyectoId);
                proyecto = proyecto.Update(model);

                if (proyecto.ProyectoId == 0)
                {
                    _proyectoRepository.Create(proyecto);
                }
                else
                {
                    _proyectoRepository.Update(proyecto);
                }

                response.ProyectoId = proyecto.ProyectoId;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public SearchProyectoUsadoResponse SearchProyectoUsado(int proyectoId)
        {
            var response = new SearchProyectoUsadoResponse();

            try
            {
                var necesidadUsandoProyecto = _necesidadRepository.Find(x => x.IsActivo && x.ProyectoId == proyectoId);
                if (necesidadUsandoProyecto == null)
                {
                    response.Usado = false;
                }
                else
                {
                    response.Usado = true;
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

        public DeleteProyectoResponse DeleteProyecto(int proyectoId)
        {
            var response = new DeleteProyectoResponse() { IsValid = true };

            try
            {
                var proyecto = _proyectoRepository.GetOne(x => x.ProyectoId == proyectoId);
                if (proyecto != null)
                {
                    proyecto.IsActivo = false;
                    _proyectoRepository.Update(proyecto);
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetSectorServicioClienteFromProyectoResponse GetSectorServicioClienteFromProyecto(int? proyectoId)
        {
            var response = new GetSectorServicioClienteFromProyectoResponse();
            try
            {                
                if(proyectoId.HasValue)
                {
                    var proyecto = _proyectoRepository.GetOne(x => x.ProyectoId == proyectoId.Value);
                    if (proyecto != null)
                    {
                        response.IsValid = true;
                        response.SectorId = proyecto.SectorId;
                        response.ServicioId = proyecto.ServicioId;
                        response.ClienteId = proyecto.ClienteId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "el proyecto especificado no existe";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "no se ha especificado Id de Proyecto";
                }
            }
            catch(Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        #endregion

        #region Private

        private IQueryable<Proyecto> Filter(IDictionary<string, string> customFilter)
        {

            Expression<Func<Proyecto, bool>> criteria = x => x.IsActivo;

            if (customFilter.ContainsKey("Nombre"))
            {
                var filtro = customFilter["Nombre"];
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    criteria = criteria.And(x => x.Nombre.Contains(filtro));
                }
            }

            if (customFilter.ContainsKey("ClienteId"))
            {
                var filtro = customFilter["ClienteId"];
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var clienteId = int.Parse(filtro);
                    criteria = criteria.And(x => x.ClienteId == clienteId);
                }
            }

            if (customFilter.ContainsKey("CentroId"))
            {
                var filtro = customFilter["CentroId"];
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var centroId = int.Parse(filtro);
                    criteria = criteria.And(x => x.CentroId == centroId);
                }
            }

            var query = _proyectoRepository.GetByCriteria(criteria);

            return query;
        }
        #endregion
    }
}
