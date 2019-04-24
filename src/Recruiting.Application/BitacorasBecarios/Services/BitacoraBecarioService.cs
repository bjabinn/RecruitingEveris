using Recruiting.Application.BitacorasBecarios.Enums;
using Recruiting.Application.BitacorasBecarios.Mappers;
using Recruiting.Application.BitacorasBecarios.Messages;
using Recruiting.Application.Usuarios.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Caching;
using Recruiting.Infra.Caching.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Recruiting.Application.BitacorasBecarios.Services
{
    public class BitacoraBecarioService : IBitacoraBecarioService
    {
        #region Constants
        public const string BitacoraFiltroSessionKey = "BitacoraFiltroSessionKey";
        private const string ERROR_MESSAGE = "Error to create Bitacora";
        #endregion

        #region Fields

        
        private readonly IMaestroRepository _maestroRepository;
        private readonly ICacheStorageService _cacheStorageService;
        private readonly IBecarioRepository _becarioRepository;
        private readonly IBitacoraBecarioRepository _bitacoraBecarioRepository;        
        private readonly ITipoEstadoBecarioRepository _tipoEstadoBecarioRepository;

        #endregion

        #region Constructor

        public BitacoraBecarioService(IBitacoraBecarioRepository bitacoraBecarioRepository)
        {

            _maestroRepository = new MaestroRepository();
            _cacheStorageService = new SessionCacheStorageService();
            _becarioRepository = new BecarioRepository();
            _bitacoraBecarioRepository = bitacoraBecarioRepository;
            _tipoEstadoBecarioRepository = new TipoEstadoBecarioRepository();
        }

        public GenerateBitacoraBecarioResponse GenerateBitacoraPausarReanudar(int becarioId, int estadoAnteriorId, int estadoNuevoId, bool esPausar)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nBecarios = _becarioRepository.CountByCriteria(x => x.BecarioId == becarioId);

                if ((userInfo == null) || (nBecarios != 1))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var msgEstado = "reanudado";
                var tipoBitacora = TipoBitacoraBecarioEnum.Reanudar;
                if (esPausar)
                {
                    tipoBitacora = TipoBitacoraBecarioEnum.Pausar;
                    msgEstado = "pausado";
                }

                var message = string.Format("El becario con referencia {0} fué {1} por el usuario: '{2}' en la fecha: '{3}'", becarioId, msgEstado, userInfo.Usuario, DateTime.Now);
                var newBecarioBitacora = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)tipoBitacora,
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };
                _bitacoraBecarioRepository.Create(newBecarioBitacora);

            }
            catch 
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;

        }

        public GetBitacorasBecarioResponse GetBitacorasByCandidaturaId(DataTableRequest request)
        {
            var response = new GetBitacorasBecarioResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BitacoraBecarioMapper.GetPropertiePath);

                response.BitacoraBecarioRowViewModel = filtered.ConvertToBitacoraBecarioRowViewModel();
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

        public GenerateBitacoraBecarioResponse GenerateBitacoraBecarioRetroceder(int becarioId, int bitacoraId)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nBecarios = _becarioRepository.CountByCriteria(x => x.BecarioId == becarioId);

                if ((userInfo == null) || (nBecarios != 1))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("Se ha deshecho el cambio de la bitacora {0} del becario {1} por el usuario: '{2}' en la fecha: '{3}'", bitacoraId, becarioId, userInfo.Usuario, DateTime.Now);

                var newBecarioBitacora = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Retroceder,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraBecarioRepository.Create(newBecarioBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioId(int becarioId)
        {
            var response = new GetLastEstadoBitacoraByBecarioIdResponse();

            try
            {
                var bitacorasRevertibles = _bitacoraBecarioRepository.GetByCriteria(x => x.BecarioId == becarioId && x.TipoBitacora.HasValue && x.Revertible.HasValue && x.Revertible.Value);

                bitacorasRevertibles = bitacorasRevertibles.OrderByDescending(x => x.BitacoraId);
                var bitacoraARevertir = bitacorasRevertibles.FirstOrDefault();

                if (bitacoraARevertir != null)
                {
                    var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                    if (becario != null && (bitacoraARevertir.EstadoAnteriorId.HasValue))
                    {  
                            response.EstadoAnteriorId = (int)bitacoraARevertir.EstadoAnteriorId;
                            response.IsValid = true;
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


        public GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioIdStandBy(int becarioId)
        {
            var response = new GetLastEstadoBitacoraByBecarioIdResponse();

            try
            {
                var bitacorasRevertiblesStandBy = _bitacoraBecarioRepository.GetByCriteria(x => x.BecarioId == becarioId && x.TipoBitacora == (int)TipoBitacoraBecarioEnum.Pausar);

                bitacorasRevertiblesStandBy = bitacorasRevertiblesStandBy.OrderByDescending(x => x.BitacoraId);
                var bitacoraARevertir = bitacorasRevertiblesStandBy.FirstOrDefault();

                if (bitacoraARevertir != null)
                {
                    var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                    if (becario != null && (bitacoraARevertir.EstadoAnteriorId.HasValue))
                    {
                            response.EstadoAnteriorId = (int)bitacoraARevertir.EstadoAnteriorId;
                            response.IsValid = true;
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

        public GenerateBitacoraBecarioResponse GenerateBitacoraDescarteBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId) 
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nBecarios =  _becarioRepository.CountByCriteria(x => x.BecarioId == becarioId);

                var estadoAnterior = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoNuevoId);

                if ((userInfo == null) || (nBecarios != 1) || (estadoAnterior == null) || 
                    (estadoNuevo == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("El becario con referencia {0} fué cambiada a 'Descartar' por el usuario: '{1}' en la fecha: '{2}'", becarioId, userInfo.Usuario, DateTime.Now); 


                var newBecarioBitacora = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Descarte,
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraBecarioRepository.Create(newBecarioBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }



        public GenerateBitacoraBecarioResponse GenerateBitacoraRenunciaBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nBecarios = _becarioRepository.CountByCriteria(x => x.BecarioId == becarioId);

                var estadoAnterior = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoNuevoId);

                if ((userInfo == null) || (nBecarios != 1) || (estadoAnterior == null) ||
                    (estadoNuevo == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("El becario con referencia {0} fué cambiada a 'Renuncia' por el usuario: '{1}' en la fecha: '{2}'", becarioId, userInfo.Usuario, DateTime.Now/*, motivoRenuncia.Nombre*/);


                var newBecarioBitacora = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Renuncia,
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraBecarioRepository.Create(newBecarioBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }


        public GenerateBitacoraBecarioResponse GenerateBitacoraCambioEstadoBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var nBecarios = _becarioRepository.CountByCriteria(x => x.BecarioId == becarioId);

                var estadoAnterior = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoAnteriorId);
                var estadoNuevo = _tipoEstadoBecarioRepository.GetOne(x => x.TipoEstadoBecarioId == estadoNuevoId);
                

                if ((userInfo == null) || (nBecarios != 1) ||
                    (estadoAnterior == null) || (estadoNuevo == null))
                    {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var str = new StringBuilder();
                str.AppendLine(string.Format("El becario con referencia {0} ha pasado del estado '{1}' a estado '{2}' en la fecha {3}.",
                    becarioId, estadoAnterior.EstadoBecario, estadoNuevo.EstadoBecario, DateTime.Now));

                var message = str.ToString();
                var newBitacora = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.CambioEstado,
                    MensajeSistema = message,
                    EstadoAnteriorId = estadoAnteriorId,
                    EstadoNuevoId = estadoNuevoId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = true,
                };

                _bitacoraBecarioRepository.Create(newBitacora);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }


        public GenerateBitacoraBecarioResponse GenerateBitacoraCreateBecario(int becarioId)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if ((userInfo == null) || (becario == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("El becario con referencia {0} fué creado por el usuario: '{1}' en la fecha: '{2}'", becarioId, userInfo.Usuario, DateTime.Now);
                var newBitacoraBecario = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Creacion,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = becario.TipoEstadoBecarioId,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraBecarioRepository.Create(newBitacoraBecario);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraEditBecarioResponse GenerateBitacoraEditBecario(int becarioId)
        {
            var response = new GenerateBitacoraEditBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if ((userInfo == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var message = string.Format("El becario con referencia {0} fué editado por el usuario: '{1}' en la fecha: '{2}'", becario.BecarioId, userInfo.Usuario, DateTime.Now);



                var newBitacoraBecario = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Edicion,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraBecarioRepository.Create(newBitacoraBecario);
            }
            catch 
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;
        }

        public GenerateBitacoraBecarioResponse GenerateBitacoraBecarioManual (int becarioId, string message)
        {
            var response = new GenerateBitacoraBecarioResponse() { IsValid = true };
            try
            {
                var userInfo = (UsuarioRolPermisoViewModel)HttpContext.Current.Session["Usuario"];
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if ((userInfo == null) || (becario == null))
                {
                    response.IsValid = false;
                    response.ErrorMessage = ERROR_MESSAGE;
                    return response;
                }

                var newBitacoraBecario = new BitacoraBecario()
                {
                    BecarioId = becarioId,
                    TipoBitacora = (int)TipoBitacoraBecarioEnum.Manual,
                    MensajeSistema = message,
                    EstadoAnteriorId = null,
                    EstadoNuevoId = null,
                    IsActivo = true,
                    CreatedBy = userInfo.UsuarioId,
                    Created = DateTime.Now,
                    Revertible = false,
                };

                _bitacoraBecarioRepository.Create(newBitacoraBecario);
            }
            catch
            {
                response.IsValid = false;
                response.ErrorMessage = ERROR_MESSAGE;
            }

            return response;

        }

        #endregion

        #region IBitacoraService



        #endregion

        #region Private Methods
        private IQueryable<BitacoraBecario> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _bitacoraBecarioRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("BitacoraId") && (customFilter["BitacoraId"] != string.Empty))
            {
                    var BitacoraId = Convert.ToInt32(customFilter["BitacoraId"]);
                    query = query.Where(x => x.BitacoraId == BitacoraId);
            }

            if (customFilter.ContainsKey("BecarioId") && (customFilter["BecarioId"] != string.Empty))
            {
                    var BecarioId = Convert.ToInt32(customFilter["BecarioId"]);
                    query = query.Where(x => x.BecarioId == BecarioId);
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
