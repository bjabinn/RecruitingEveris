using Recruiting.Application.BitacorasNecesidades.Enums;
using Recruiting.Application.BitacorasNecesidades.Mappers;
using Recruiting.Application.BitacorasNecesidades.Messages;
using Recruiting.Application.BitacorasNecesidades.ViewModels;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Infra.Caching;
using Recruiting.Infra.Caching.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Recruiting.Application.BitacorasNecesidades.Services
{
    public class BitacoraNecesidadService : IBitacoraNecesidadService
    {
        #region Constants
        public const string BitacoraFiltroSessionKey = "BitacoraFiltroSessionKey";
        private const string ERROR_MESSAGE = "Error to create Bitacora";
        #endregion

        #region Fields

        private readonly IBitacoraNecesidadRepository _bitacoraNecesidadRepository;
        private readonly INecesidadRepository _necesidadRepository;
        private readonly IMaestroRepository _maestroRepository;
        private readonly ICacheStorageService _cacheStorageService;       
        #endregion

        #region Constructor

        public BitacoraNecesidadService(IBitacoraNecesidadRepository bitacoraNecesidadRepository, INecesidadRepository necesidadRepository, IMaestroRepository maestroRepository)
        {
            _bitacoraNecesidadRepository = bitacoraNecesidadRepository;
            _necesidadRepository = necesidadRepository;
            _maestroRepository = maestroRepository;
            _cacheStorageService = new SessionCacheStorageService();
        }

        #endregion

        #region IBitacoraService

        public GetBitacorasNecesidadResponse GetBitacorasByNecesidadId(DataTableRequest request)
        {
            var response = new GetBitacorasNecesidadResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BitacoraNecesidadMapper.GetPropertiePath);

                response.BitacoraNecesidadRowViewModel = filtered.ConvertToBitacoraNecesidadRowViewModel().OrderByDescending(x=> x.BitacoraId);
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


        public GenerateBitacoraNecesidadResponse GenerateBitacoraCreateNecesidad(int necesidadId)
        {
            var response = new GenerateBitacoraNecesidadResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId);

                if ((userInfo == null) || (necesidad == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La necesidad con referencia {0} fué creada por el usuario: '{1}' en la fecha: '{2}'", necesidadId, userInfo.Usuario, DateTime.Now);
                var newBitacora = new BitacoraNecesidad()
                {
                    NecesidadId = necesidadId,
                    TipoBitacora = (int)TipoBitacoraNecesidadEnum.Creacion,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = necesidad.EstadoNecesidadId,
                    PerfilAnteriorId = null,
                    PerfilNuevoId = necesidad.TipoPerfilId,
                    FechaSolicitudAnterior = null,
                    FechaSolicitudNueva = necesidad.FechaSolicitud,
                    FechaCompromisoAnterior = null,
                    FechaCompromisoNueva = necesidad.FechaCompromiso,
                    FechaCierreAnterior = null,
                    FechaCierreNueva = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,                   
                };

                _bitacoraNecesidadRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraEditNecesidadResponse GenerateBitacoraEditNecesidad(DatosComparativaBitacoraViewModel datosBitacoraViewModel)
        {
            var response = new GenerateBitacoraEditNecesidadResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nombreEstadoAnterior = _maestroRepository.GetOne(x => x.MaestroId == datosBitacoraViewModel.EstadoAnteriorId);
                var nombreEstadoNuevo = _maestroRepository.GetOne(x => x.MaestroId == datosBitacoraViewModel.EstadoNuevoId);
                var nombrePerfilAnterior = _maestroRepository.GetOne(x => x.MaestroId == datosBitacoraViewModel.PerfilAnteriorId);
                var nombrePerfilNuevo = _maestroRepository.GetOne(x => x.MaestroId == datosBitacoraViewModel.PerfilNuevoId);
                var personaAsignadaAnterior = datosBitacoraViewModel.PersonaAsignadaAnterior;
                var personaAsignadaNueva = datosBitacoraViewModel.PersonaAsignadaNueva;

                if ((userInfo == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La necesidad con referencia {0} fué editada por el usuario: '{1}' en la fecha: '{2}'", datosBitacoraViewModel.NecesidadId, userInfo.Usuario, DateTime.Now);
                if (datosBitacoraViewModel.EstadoAnteriorId != datosBitacoraViewModel.EstadoNuevoId)
                {
                    message = message + string.Format("\nEl estado ha cambiado de '{0}' a '{1}'", nombreEstadoAnterior.Nombre, nombreEstadoNuevo.Nombre);
                }
                if (personaAsignadaAnterior != personaAsignadaNueva)
                {
                    if (personaAsignadaAnterior !=null && personaAsignadaNueva != null)
                    {
                        message = message + string.Format("\nSe ha cambiado la persona asignada de {0} a {1}", personaAsignadaAnterior, personaAsignadaNueva);
                    }
                    else if(personaAsignadaNueva == null)
                    {
                        message = message + string.Format("\nSe ha liberado la persona asignada {0}", personaAsignadaAnterior);
                    }
                    else 
                    {
                        message = message + string.Format("\nSe ha asignado la persona {0}", personaAsignadaNueva);
                    }
                }

                if (datosBitacoraViewModel.PerfilAnteriorId != datosBitacoraViewModel.PerfilNuevoId)
                {
                    message = message + string.Format("\nEl perfil ha cambiado de '{0}' a '{1}'", nombrePerfilAnterior.Nombre, nombrePerfilNuevo.Nombre);
                }
                if(datosBitacoraViewModel.FechaSolicitudAnterior != datosBitacoraViewModel.FechaSolicitudNueva)
                {
                    message = message + string.Format("\nLa fecha de solicitud ha cambiado de '{0}' a '{1}'", datosBitacoraViewModel.FechaSolicitudAnterior, datosBitacoraViewModel.FechaSolicitudNueva);
                }
                
                if (datosBitacoraViewModel.FechaCompromisoAnterior != datosBitacoraViewModel.FechaCompromisoNueva)
                {
                    if(datosBitacoraViewModel.FechaCompromisoAnterior != null)
                    {
                        message = message + string.Format("\nLa fecha de compromiso ha cambiado de '{0}' a '{1}'", datosBitacoraViewModel.FechaCompromisoAnterior, datosBitacoraViewModel.FechaCompromisoNueva);
                    }
                    else
                    {
                        message = message + string.Format("\nSe ha asignado la fecha de compromiso '{0}'", datosBitacoraViewModel.FechaCompromisoNueva);
                    }                    
                }
                if (datosBitacoraViewModel.FechaCierreAnterior != datosBitacoraViewModel.FechaCierreNueva)
                {
                    if (datosBitacoraViewModel.FechaCierreAnterior != null)
                    {
                        message = message + string.Format("\nLa fecha de cierre ha cambiado de '{0}' a '{1}'", datosBitacoraViewModel.FechaCierreAnterior, datosBitacoraViewModel.FechaCierreNueva);
                    }
                    else
                    {
                        message = message + string.Format("\nSe ha asignado la fecha de cierre '{0}'", datosBitacoraViewModel.FechaCierreNueva);
                    }
                }
                var newBitacora = new BitacoraNecesidad()
                {
                    NecesidadId = datosBitacoraViewModel.NecesidadId,
                    TipoBitacora = (int)TipoBitacoraNecesidadEnum.Edicion,
                    MensajeSistema = message,
                    EstadoAnteriorId = datosBitacoraViewModel.EstadoAnteriorId,
                    EstadoNuevoId = datosBitacoraViewModel.EstadoNuevoId,
                    PerfilAnteriorId = datosBitacoraViewModel.PerfilAnteriorId,
                    PerfilNuevoId = datosBitacoraViewModel.PerfilNuevoId,
                    FechaSolicitudAnterior = datosBitacoraViewModel.FechaSolicitudAnterior,
                    FechaSolicitudNueva = datosBitacoraViewModel.FechaSolicitudNueva,
                    FechaCompromisoAnterior = datosBitacoraViewModel.FechaCompromisoAnterior,
                    FechaCompromisoNueva = datosBitacoraViewModel.FechaCompromisoNueva,
                    FechaCierreAnterior = datosBitacoraViewModel.FechaCierreAnterior,
                    FechaCierreNueva = datosBitacoraViewModel.FechaCierreNueva,
                    PersonaAsignadaAnterior = datosBitacoraViewModel.PersonaAsignadaAnterior,
                    PersonaAsignadaNueva = datosBitacoraViewModel.PersonaAsignadaNueva,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                };

                _bitacoraNecesidadRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraNecesidadResponse GenerateBitacoraNecesidadManual(int necesidadId, string message)
        {
            var response = new GenerateBitacoraNecesidadResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var necesidad = _necesidadRepository.GetOne(x => x.NecesidadId == necesidadId);

                if ((userInfo == null) || (necesidad == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }


                var newBitacora = new BitacoraNecesidad()
                {
                    NecesidadId = necesidadId,
                    TipoBitacora = (int)TipoBitacoraNecesidadEnum.Manual,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = null,
                    PerfilAnteriorId = null,
                    PerfilNuevoId = null,
                    FechaSolicitudAnterior = null,
                    FechaSolicitudNueva = null,
                    FechaCompromisoAnterior = null,
                    FechaCompromisoNueva = null,
                    FechaCierreAnterior = null,
                    FechaCierreNueva = null,
                    PersonaAsignadaAnterior = null,
                    PersonaAsignadaNueva = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                };

                _bitacoraNecesidadRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }


        #endregion

        #region Private Methods
        private IQueryable<BitacoraNecesidad> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _bitacoraNecesidadRepository.GetAll();

            query = query.Where(x => x.IsActivo).OrderByDescending(x => x.BitacoraId);

            if (customFilter.ContainsKey("BitacoraId") && (customFilter["BitacoraId"] != string.Empty))
            {
                    var BitacoraId = Convert.ToInt32(customFilter["BitacoraId"]);
                    query = query.Where(x => x.BitacoraId == BitacoraId);
            }

            if (customFilter.ContainsKey("NecesidadId") && (customFilter["NecesidadId"] != string.Empty))
            {
                    var NecesidadId = Convert.ToInt32(customFilter["NecesidadId"]);
                    query = query.Where(x => x.NecesidadId == NecesidadId);
            }

            if (customFilter.ContainsKey("MensajeSistema") && (customFilter["MensajeSistema"] != string.Empty))
            {
                    var MensajeSistema = customFilter["MensajeSistema"];
                    query = query.Where(x => x.MensajeSistema.Contains(MensajeSistema));
            }

            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty || customFilter.ContainsKey("CentroSearch")))
            {
                    if (customFilter.ContainsKey("CentroSearch"))
                    {
                        if (customFilter["CentroSearch"] != string.Empty)
                        {
                            var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                            query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                        }
                        else
                        {
                            if (customFilter["CentroUsuarioId"] != string.Empty)
                            {
                                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                                query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                            }
                        }
                    }
                    else
                    {
                        var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                        query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                    }
            }

            if (customFilter.ContainsKey("CentroSearch") && !customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroSearch"] != string.Empty))
            {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                    query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
            }

            return query;

        }
        #endregion

    }
}
