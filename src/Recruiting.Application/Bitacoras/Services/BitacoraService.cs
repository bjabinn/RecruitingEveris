using Recruiting.Application.Bitacoras.Enums;
using Recruiting.Application.Bitacoras.Mappers;
using Recruiting.Application.Bitacoras.Messages;
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
using System.Text;
using System.Web;

namespace Recruiting.Application.Bitacoras.Services
{
    public class BitacoraService : IBitacoraService
    {
        #region Constants
        public const string BitacoraFiltroSessionKey = "BitacoraFiltroSessionKey";
        private const string ERROR_MESSAGE = "Error to create Bitacora";
        #endregion

        #region Fields

        private readonly IBitacoraRepository _bitacoraRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly ICacheStorageService _cacheStorageService;

        private readonly ITipoDecisionRepository _tipoDecisionRepository;
        private readonly ITipoEtapaCandidaturaRepository _tipoEtapaCandidaturaRepository;
        private readonly ITipoEstadoCandidaturaRepository _tipoEstadoCandidaturaRepository;
        private readonly IMaestroRepository _maestroRepository;
        #endregion

        #region Constructor

        public BitacoraService(IBitacoraRepository bitacoraRepository, ICandidaturaRepository candidaturaRepository, ITipoDecisionRepository tipoDecisionRepository,
             ITipoEtapaCandidaturaRepository tipoEtapaCandidaturaRepository, ITipoEstadoCandidaturaRepository tipoEstadoCandidaturaRepository,
             IMaestroRepository maestroRepository)
        {
            _bitacoraRepository = bitacoraRepository;
            _candidaturaRepository = candidaturaRepository;
            _tipoDecisionRepository = tipoDecisionRepository;
            _tipoEtapaCandidaturaRepository = tipoEtapaCandidaturaRepository;
            _tipoEstadoCandidaturaRepository = tipoEstadoCandidaturaRepository;

            _maestroRepository = maestroRepository;

            _cacheStorageService = new SessionCacheStorageService();
        }

        #endregion

        #region IBitacoraService
        public GetBitacorasResponse GetBitacorasByCandidaturaId(DataTableRequest request)
        {
            var response = new GetBitacorasResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BitacoraMapper.GetPropertiePath);

                response.BitacoraViewModel = filtered.ConvertToBitacoraRowViewModel();
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

        public GetLastBitacoraByCandidaturaIdResponse GetLastBitacoraByCandidaturaId(int candidaturaId)
        {
            var response = new GetLastBitacoraByCandidaturaIdResponse();

            try
            {
                 var bitacoras = _bitacoraRepository.GetByCriteria(x=> x.CandidaturaId == candidaturaId).ConvertToBitacoraCorreoViewModel();
                response.BitacoraCorreoViewModel = bitacoras.OrderByDescending(x => x.BitacoraId).FirstOrDefault();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraCreateCandidatura(int candidaturaId)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (candidatura == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La candidatura con referencia {0} fué creada por el usuario: '{1}' en la fecha: '{2}'", candidaturaId, userInfo.Usuario, DateTime.Now);
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Creacion,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = candidatura.EstadoCandidaturaId,
                    EtapaNuevaId = candidatura.EtapaCandidaturaId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }       

        public GenerateBitacoraResponse GenerateBitacoraCambioEstadoCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int etapaNuevaId, int? decisionId = null)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidaturas = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                var estadoAnterior = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoNuevoId);
                var etapaAnterior = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == etapaAnteriorId);
                var etapaNueva = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == etapaNuevaId);
                TipoDecision decision = null;
                if (decisionId.HasValue)
                {
                    decision = _tipoDecisionRepository.GetOne(x => x.TipoDecisionId == decisionId.Value);
                }

                if ((userInfo == null) || (nCandidaturas != 1) ||
                    (estadoAnterior == null) || (estadoNuevo == null) ||
                    (etapaAnterior == null) || (etapaNueva == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var str = new StringBuilder();
                str.AppendLine(string.Format("La candidatura con referencia {0} ha pasado del estado '{1}' y etapa '{2}' a estado '{3}' y etapa '{4}'.",
                    candidaturaId, estadoAnterior.EstadoCandidatura, etapaAnterior.EtapaCandidatura, estadoNuevo.EstadoCandidatura, etapaNueva.EtapaCandidatura));

                str.Append(string.Format("Decision tomada por el usuario: '{0}' en la fecha: '{1}'", userInfo.Usuario, DateTime.Now));

                if (decision != null)
                {
                    str.Append(string.Format(" ==> '{0}'.", decision.Decision));
                }

                var message = str.ToString();
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.CambioEstado,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EtapaAnteriorId = etapaAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    EtapaNuevaId = etapaNuevaId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraEdicionCandidatura(int candidaturaId)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (candidatura == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La candidatura con referencia {0} fué editada por el usuario: '{1}' en la fecha: '{2}'", candidaturaId, userInfo.Usuario, DateTime.Now);
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Edicion,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = candidatura.EstadoCandidaturaId,
                    EtapaNuevaId = candidatura.EtapaCandidaturaId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraRenunciaCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int motivoRenunciaId)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidaturas = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                var estadoAnterior = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoNuevoId);
                var etapaAnterior = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == etapaAnteriorId);

                var motivoRenuncia = _maestroRepository.GetOne(x => x.MaestroId == motivoRenunciaId);

                if ((userInfo == null) || (nCandidaturas != 1) ||
                    (estadoAnterior == null) || (estadoNuevo == null) ||
                    (etapaAnterior == null) || (motivoRenuncia == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La candidatura con referencia {0} fué cambiada a 'Renuncia' por el usuario: '{1}' en la fecha: '{2}'. Motivo: {3}", candidaturaId, userInfo.Usuario, DateTime.Now, motivoRenuncia.Nombre);
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Renuncia,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EtapaAnteriorId = etapaAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    EtapaNuevaId = etapaAnteriorId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraDescarteCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int motivoDescarteId)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidaturas = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                var estadoAnterior = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoCandidaturaRepository.GetOne(x => x.TipoEstadoCandidaturaId == estadoNuevoId);
                var etapaAnterior = _tipoEtapaCandidaturaRepository.GetOne(x => x.TipoEtapaCandidaturaId == etapaAnteriorId);

                var motivoDescarte = _maestroRepository.GetOne(x => x.MaestroId == motivoDescarteId);

                if ((userInfo == null) || (nCandidaturas != 1) ||
                    (estadoAnterior == null) || (estadoNuevo == null) ||
                    (etapaAnterior == null) || (motivoDescarte == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La candidatura con referencia {0} fué cambiada a 'Descartar' por el usuario: '{1}' en la fecha: '{2}'. Motivo: {3}", candidaturaId, userInfo.Usuario, DateTime.Now, motivoDescarte.Nombre);
                

                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Descarte,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EtapaAnteriorId = etapaAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    EtapaNuevaId = etapaAnteriorId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraPausarReanudar(int candidaturaId, bool esPausar)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidatura = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (nCandidatura != 1))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var msgEstado = "reanudada";
                var tipoBitacora = TipoBitacoraEnum.Reanudar;
                if (esPausar)
                {
                    tipoBitacora = TipoBitacoraEnum.Pausar;
                    msgEstado = "pausada";
                }

                var message = string.Format("La candidatura con referencia {0} fué {1} por el usuario: '{2}' en la fecha: '{3}'", candidaturaId, msgEstado, userInfo.Usuario, DateTime.Now);
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)tipoBitacora,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = null,
                    EtapaNuevaId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraManual(int candidaturaId, string mensaje)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidatura = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (nCandidatura != 1) || string.IsNullOrWhiteSpace(mensaje))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Manual,
                    Observaciones = "",
                    MensajeSistema = mensaje,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = null,
                    EtapaNuevaId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraCorreo(int candidaturaId, string mensaje)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidatura = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (nCandidatura != 1) || string.IsNullOrWhiteSpace(mensaje))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Correo,
                    Observaciones = "",
                    MensajeSistema = mensaje,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = null,
                    EtapaNuevaId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraRetroceder(int candidaturaId, int bitacoraId)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nCandidatura = _candidaturaRepository.CountByCriteria(x => x.CandidaturaId == candidaturaId);

                if ((userInfo == null) || (nCandidatura != 1))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("Se ha deshecho el cambio de la bitacora {0} de la candidatura {1} por el usuario: '{2}' en la fecha: '{3}'", bitacoraId, candidaturaId, userInfo.Usuario, DateTime.Now);

                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Retroceder,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = null,
                    EtapaNuevaId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraResponse GenerateBitacoraCrearCandidaturaOtherInfo(int candidaturaId, string usuarioCreacion)
        {
            var response = new GenerateBitacoraResponse() { IsValid = true };
            try
            {
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidaturaId == candidaturaId);

                if ((candidatura == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("La candidatura con referencia {0} fué creada por el usuario: '{1}' en la fecha: '{2}'", candidaturaId, usuarioCreacion, DateTime.Now);
                var newBitacora = new Bitacora()
                {
                    CandidaturaId = candidaturaId,
                    TipoBitacora = (int)TipoBitacoraEnum.Creacion,
                    Observaciones = "",
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EtapaAnteriorId = null,
                    EstadoNuevoId = candidatura.EstadoCandidaturaId,
                    EtapaNuevaId = candidatura.EtapaCandidaturaId,
                    IsActivo = true,
                    CreatedBy = candidatura.CreatedBy,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraRepository.Create(newBitacora);
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
        private IQueryable<Bitacora> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _bitacoraRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("BitacoraId") && (customFilter["BitacoraId"] != string.Empty))
            {
                    var BitacoraId = Convert.ToInt32(customFilter["BitacoraId"]);
                    query = query.Where(x => x.BitacoraId == BitacoraId);
            }

            if (customFilter.ContainsKey("CandidaturaId") && (customFilter["CandidaturaId"] != string.Empty))
            {
                    var CandidaturaId = Convert.ToInt32(customFilter["CandidaturaId"]);
                    query = query.Where(x => x.CandidaturaId == CandidaturaId);
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
