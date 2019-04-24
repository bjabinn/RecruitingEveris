using Recruiting.Application.Becarios.Enums;
using Recruiting.Application.Becarios.Mappers;
using Recruiting.Application.Becarios.Messages;
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Application.BitacorasBecarios.Services;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Helpers;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Recruiting.Application.Becarios.Services
{
    public class BecarioService : IBecarioService
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IBecarioObservacionRepository _becarioObservacionRepository;
        private readonly IBecarioRepository _becarioRepository;
        private readonly IBitacoraBecarioService _bitacoraBecarioService;
        private readonly IBitacoraBecarioRepository _bitacoraBecarioRepository;    
        private readonly ICandidaturaRepository _candidaturaRepository;
        private readonly ICandidatoContactoRepository _candidatoContactoRepository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BecarioService(IBecarioRepository becarioRepository, IBecarioObservacionRepository becarioObservacionRepository, IBitacoraBecarioRepository bitacoraBecarioRepository)
        {
            _becarioRepository = becarioRepository;
            _becarioObservacionRepository = becarioObservacionRepository;
            _bitacoraBecarioRepository = bitacoraBecarioRepository;
            _bitacoraBecarioService = new BitacoraBecarioService(_bitacoraBecarioRepository);
            _candidaturaRepository = new CandidaturaRepository();
            _candidatoContactoRepository = new CandidatoContactoRepository();

        }

        #endregion

        #region ICandidatoService members

        public GetBecarioByIdResponse GetBecarioById(int? becarioId)
        {
            var response = new GetBecarioByIdResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidatoId == becario.CandidatoId);
                var createEditBecarioViewModel = becario.ConvertToCreateEditBecarioViewModel();
                var emails = new List<string>();

                if (candidatura != null){
                    if (candidatura.EmailsReferenciados != null)
                    {
                        emails = candidatura.EmailsReferenciados.Split(';').ToList();
                    }

                    if (emails.Count > 0 && emails.Last() == "")
                    {
                        emails.RemoveAt(emails.Count - 1);
                    }

                    createEditBecarioViewModel.BecarioDatosBasicos.OrigenCvId = candidatura.OrigenCvId;
                    createEditBecarioViewModel.BecarioDatosBasicos.FuenteReclutamientoId = candidatura.FuenteReclutamientoId;
                    createEditBecarioViewModel.BecarioDatosBasicos.ListEmailReferenciados = emails;

                }

                response.BecarioViewModel = createEditBecarioViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RemoveBecarioResponse RemoveBecario(int becarioId)
        {
            var response = new RemoveBecarioResponse();
            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);
                //cambiamos el activo a =0(borrado lógico)
                becario.IsActivo = false;
                if (_becarioRepository.Update(becario) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error deleting Becario";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetBecariosResponse GetBecarios(DataTableRequest request)
        {
            var response = new GetBecariosResponse();

            try
            {

                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BecarioMapper.GetPropertiePath);

                response.BecarioRowViewModel = filtered.ConvertToBecarioRowViewModel();
                if (response.BecarioRowViewModel != null)
                {
                    foreach (var becarioRow in response.BecarioRowViewModel)
                    {
                            var candidaturaExistente = _candidaturaRepository.Find(x=> x.CandidatoId == becarioRow.CandidatoId && x.IsActivo &&
                                                                                   x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Descartado &&
                                                                                   x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Recontactado &&
                                                                                   x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.Renuncia &&
                                                                                   x.EstadoCandidaturaId != (int)TipoEstadoCandidaturaEnum.RechazaOferta);
                        if (candidaturaExistente == null)
                        {
                            becarioRow.ExisteCandidatura = false;
                        }
                        else
                        {
                            becarioRow.ExisteCandidatura = true;
                        }
                    }
                }

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

        public GetBecariosExportToExcelResponse GetBecariosExportToExcel(DataTableRequest request)
        {
            var response = new GetBecariosExportToExcelResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BecarioMapper.GetPropertiePath);

                response.BecarioRowExportToExcelViewModel = filtered.ConvertToBecarioRowExportToExcelViewModel();
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

        public PauseBecarioResponse PauseBecario(int becarioId, DateTime? fechaContactoStandBy = null)
        {
            var response = new PauseBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if (becario != null)
                {
                    var estadoAnteriorId = becario.TipoEstadoBecarioId;
                    becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Stand_By;
                    becario.FechaContactoStandBy = fechaContactoStandBy;

                    if (_becarioRepository.Update(becario) > 0)
                    {
                        var estadoNuevoId = becario.TipoEstadoBecarioId;
                        var bitacoraBecarioResponse = _bitacoraBecarioService.GenerateBitacoraPausarReanudar(becarioId, estadoAnteriorId, estadoNuevoId, true);
                        response.IsValid = true;
                        response.ErrorMessage = bitacoraBecarioResponse.ErrorMessage;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to pause Becario";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to pause Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public ResumeBecarioResponse ResumeBecario(int becarioId)
        {
            var response = new ResumeBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if (becario != null)
                {
                    var estadoAnteriorId = becario.TipoEstadoBecarioId;
                    var estadoNuevoResponse  = _bitacoraBecarioService.GetLastEstadoBitacoraByBecarioIdStandBy(becarioId);
                    if(estadoNuevoResponse.IsValid)
                    {
                        becario.TipoEstadoBecarioId = estadoNuevoResponse.EstadoAnteriorId;
                    }
                    else
                    {
                        becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Inicio;
                    }
                    becario.FechaContactoStandBy = null;

                    if (_becarioRepository.Update(becario) > 0)
                    {
                        var estadoNuevoId = becario.TipoEstadoBecarioId;
                        var bitacoraBecarioResponse = _bitacoraBecarioService.GenerateBitacoraPausarReanudar(becarioId, estadoAnteriorId, estadoNuevoId, false);
                        response.IsValid = true;
                        response.ErrorMessage = bitacoraBecarioResponse.ErrorMessage;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to resume Becario";
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to resume Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


   
        public ExecuteBecarioResponse ExecuteBecario(int becarioId)
        {
            var response = new ExecuteBecarioResponse() { IsValid = true };

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);


                switch (becario.TipoEstadoBecarioId)
                {
                    case (int)TipoEstadoBecarioEnum.Inicio:
                        {
                            int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                            becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.En_Proceso;

                            _bitacoraBecarioService.GenerateBitacoraCambioEstadoBecario(becario.BecarioId, estadoBecarioInicial, becario.TipoEstadoBecarioId);

                            response.VistaAMostrar = "Index";
                            break;
                        }
                    case (int)TipoEstadoBecarioEnum.En_Proceso:
                        {
                            response.VistaAMostrar = "EnProceso";
                            break;
                        }
                    case (int)TipoEstadoBecarioEnum.Seleccionado:
                        {
                            response.VistaAMostrar = "Seleccion";
                            break;
                        }
                    case (int)TipoEstadoBecarioEnum.Practicas:
                        {
                            response.VistaAMostrar = "Practicas";
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

                if (_becarioRepository.Update(becario) <= 0)
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to execute Becario";
                    return response;
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

        public SaveProcesoBecarioResponse SaveProcesoBecario(BecarioObservacionesViewModel observacionesViewModel, bool changeEtapa)
        {
            var response = new SaveProcesoBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == observacionesViewModel.BecarioId);
                becario.UpdateBecario(observacionesViewModel);
                if (observacionesViewModel.BecarioObservacionList != null)
                {
                    foreach (var observacionViewModel in observacionesViewModel.BecarioObservacionList)
                    {
                        observacionViewModel.BecarioId = observacionesViewModel.BecarioId;
                        var observacion = new BecarioObservacion();
                        if (observacionViewModel.ObservacionId != null)
                        {
                            observacion = _becarioObservacionRepository.GetOne(x => x.BecarioObservacionId == (int)observacionViewModel.ObservacionId);
                        }

                        observacion.UpdateObservacion(observacionViewModel);
                        if (observacion.BecarioObservacionId == 0)
                        {
                            _becarioObservacionRepository.Create(observacion);
                        }
                        else
                        {
                            _becarioObservacionRepository.Update(observacion);
                        }

                    }
                }
                if (observacionesViewModel.ObservacionesBorradas.Length > 0)
                {
                    foreach (var id in observacionesViewModel.ObservacionesBorradas)
                    {
                        if (id != "" && id != null)
                        {
                            var idBorrar = Convert.ToInt32(id);
                            var observacion = _becarioObservacionRepository.GetOne(x => x.BecarioObservacionId == idBorrar);
                            observacion.IsActivo = false;
                            _becarioObservacionRepository.Update(observacion);
                        }
                    }
                }
                if (_becarioRepository.Update(becario) > 0)
                {

                    if (changeEtapa)
                    {
                        if (ChangeEtapa(observacionesViewModel.BecarioId))
                        {
                            response.IsValid = true;

                        }
                        else
                        {
                            response.IsValid = false;
                        }
                    }
                    else
                    {
                        response.IsValid = true;
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveSeleccionBecarioResponse SaveSeleccionBecario(BecarioSeleccionViewModel seleccionViewModel, bool changeEtapa)
        {
            var response = new SaveSeleccionBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == seleccionViewModel.BecarioId);
                becario.UpdateBecario(seleccionViewModel);

                if (_becarioRepository.Update(becario) > 0)
                {

                    if (changeEtapa)
                    {
                        if (ChangeEtapa((int)seleccionViewModel.BecarioId))
                        {
                            response.IsValid = true;

                        }
                        else
                        {
                            response.IsValid = false;
                        }
                    }
                    else
                    {
                        response.IsValid = true;
                    }

                    response.BecarioId = becario.BecarioId;
                    response.NombreAnexo = becario.NombreAnexo;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SavePracticasBecarioResponse SavePracticasBecario(BecarioDatosPracticasViewModel practicasViewModel, bool changeEtapa)
        {
            var response = new SavePracticasBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == practicasViewModel.BecarioId);
                becario.UpdateBecario(practicasViewModel);

                if (_becarioRepository.Update(becario) > 0)
                {

                    if (changeEtapa)
                    {
                        if (ChangeEtapa((int)practicasViewModel.BecarioId))
                        {
                            response.IsValid = true;

                        }
                        else
                        {
                            response.IsValid = false;
                        }
                    }
                    else
                    {
                        response.IsValid = true;
                    }
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        private bool ChangeEtapa(int becarioId)
        {
            var success = true;

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                if (becario.TipoEstadoBecarioId == (int)TipoEstadoBecarioEnum.En_Proceso)
                {
                    if (becario.SuperaProceso)
                    {
                        int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                        becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Seleccionado;
                        //cambio estado
                        _bitacoraBecarioService.GenerateBitacoraCambioEstadoBecario(becario.BecarioId, estadoBecarioInicial, becario.TipoEstadoBecarioId);
                    }
                    else
                    {
                        int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                        becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Descartado;
                        //descartado

                        if(becario.TipoBecarioId == (int)TipoBecaEnum.BecaInterna)
                        {
                            becario.NotificarDescarte = true;
                        }

                        _bitacoraBecarioService.GenerateBitacoraDescarteBecario(
                            becarioId: becario.BecarioId,
                            estadoAnteriorId: estadoBecarioInicial,
                            estadoNuevoId: becario.TipoEstadoBecarioId
                            //motivoDescarteId: 
                            );
                    }
                    _becarioRepository.Update(becario);
                }
                else if (becario.TipoEstadoBecarioId == (int)TipoEstadoBecarioEnum.Seleccionado)
                {
                    int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                    becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Practicas;
                    _becarioRepository.Update(becario);
                    _bitacoraBecarioService.GenerateBitacoraCambioEstadoBecario(becario.BecarioId, estadoBecarioInicial, becario.TipoEstadoBecarioId);
                }
                else if (becario.TipoEstadoBecarioId == (int)TipoEstadoBecarioEnum.Practicas)
                {
                    int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                    becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Finalizado;
                    _becarioRepository.Update(becario);
                    _bitacoraBecarioService.GenerateBitacoraCambioEstadoBecario(becario.BecarioId, estadoBecarioInicial, becario.TipoEstadoBecarioId);
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

        public SaveBecarioResponse SaveBecario(BecarioDatosBasicosViewModel becarioDatosBasicosViewModel, bool changeEtapa)
        {
            var response = new SaveBecarioResponse() { IsValid = true };

            try
            {
                var becario = new Becario();
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidatoId == becarioDatosBasicosViewModel.CandidatoId);

                if (becarioDatosBasicosViewModel.BecarioId.HasValue)
                {
                    becario = _becarioRepository.GetOne(x => x.BecarioId == becarioDatosBasicosViewModel.BecarioId.Value);
                }

                becario.UpdateBecario(becarioDatosBasicosViewModel);

                //Actualizamos la candidatura asociada si existiese
                if (candidatura != null)
                {
                    candidatura.OrigenCvId = becario.OrigenCvId;
                    candidatura.FuenteReclutamientoId = becario.FuenteReclutamientoId;
                    candidatura.EmailsReferenciados = becario.EmailsReferenciados;
                    _candidaturaRepository.Update(candidatura);
                }

                //Actualizamos o creamos becario    
                if (becario.BecarioId > 0)
                {
                    _becarioRepository.Update(becario);
                }
                else
                {
                    becario.UrlCV = becarioDatosBasicosViewModel.UrlCV;
                    becario = _becarioRepository.Create(becario);
                    _bitacoraBecarioService.GenerateBitacoraCreateBecario(becario.BecarioId);
                }

                response.BecarioId = becario.BecarioId;
                response.NombreCV = becario.NombreCV;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public RevokeBecarioResponse RevokeBecario(int becarioId, string ComentariosRenunciaDescarte = null)//, int TipoRenunciaDescarte)
        {
            var response = new RevokeBecarioResponse();

            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                int estadoBecarioInicial = becario.TipoEstadoBecarioId;

                becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Renuncia;
                becario.ComentarioRenunciaDescarte = ComentariosRenunciaDescarte;

                if (_becarioRepository.Update(becario) > 0)
                {
                    var responseBitacora = _bitacoraBecarioService.GenerateBitacoraRenunciaBecario(
                        becarioId: becario.BecarioId,
                        estadoAnteriorId: estadoBecarioInicial,
                        estadoNuevoId: becario.TipoEstadoBecarioId);

                    response.IsValid = responseBitacora.IsValid;
                    response.ErrorMessage = responseBitacora.ErrorMessage;
                    //response.IsValid = true; //quitar cuando este la bitacora
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to revoke Becario";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public UploadCVResponse UploadCV(byte[] curriculum, int becarioId, string nombreCv)
        {
            var response = new UploadCVResponse();
            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);
                if (becario != null)
                {
                    var ruta = ConfigurationManager.AppSettings["rutaCVBecarios"].ToString(); //cogemos la ruta que hayamos definido en el Web.Config
                    var becarioIdString = becario.BecarioId.ToString(); // pasamos a string la candidaturaId
                    if (!System.IO.Directory.Exists(ruta))//si no existe la ruta del Web.Config
                    {
                        System.IO.Directory.CreateDirectory(ruta); //la creamos
                    }
                    var rutaPosible = System.IO.Path.Combine(ruta, becarioIdString); //definimos un subdirectorio dentro de nuestra ruta que sea la candidaturaId
                    if (becario.NombreCV != null && System.IO.Directory.Exists(rutaPosible)) //si nuestra antigua candidatura tiene algun curriculum subido y la ruta existe
                    {
                        var rutaExistente = System.IO.Path.Combine(ruta, becarioIdString, becario.NombreCV); // definimos la ruta hasta el nombre del curriculum anterior
                        if (System.IO.File.Exists(rutaExistente)) // comprobamos si este archivo existe por si hubiera habido anteriormente un fallo a mitad del procedimiento y se hubiese creado la carpeta pero no el archivo
                        {
                            System.IO.File.Delete(rutaExistente); // borramos el curriculum antiguo
                        }
                    }
                    var rutaNuevoFichero = System.IO.Path.Combine(rutaPosible, nombreCv); // ahora definimos la ruta con el nombre del fichero de nuestro nuevo cv
                    System.IO.Directory.CreateDirectory(rutaPosible); // creamos el subdirectorio con el nombre de candidaturaId (si ya existia no hara nada)
                    using (System.IO.FileStream fs = System.IO.File.Create(rutaNuevoFichero)) // creamos un file stream para crear nuestro nuevo fichero
                    {
                        foreach (byte i in curriculum)
                        {
                            fs.WriteByte(i); //recorremos byte a byte nuestro curriculum enviado y lo escribimos en la ruta especificada
                        }
                    }
                    becario.CV = null; // Eliminar cuando el curriculum se almacene por ruta en BD
                    becario.NombreCV = nombreCv;
                    becario.UrlCV = ruta;
                    _becarioRepository.Update(becario);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Failed to access the becario";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public UploadCVResponse UploadAnexo(byte[] anexo, int becarioId, string nombreAnexo)
        {
            var response = new UploadCVResponse();
            try
            {
                var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);
                if (becario != null)
                {
                    var ruta = ConfigurationManager.AppSettings["rutaAnexoBecarios"].ToString(); //cogemos la ruta que hayamos definido en el Web.Config
                    var becarioIdString = becario.BecarioId.ToString(); // pasamos a string la candidaturaId
                    if (!System.IO.Directory.Exists(ruta))//si no existe la ruta del Web.Config
                    {
                        System.IO.Directory.CreateDirectory(ruta); //la creamos
                    }
                    var rutaPosible = System.IO.Path.Combine(ruta, becarioIdString); //definimos un subdirectorio dentro de nuestra ruta que sea la candidaturaId
                    if (becario.NombreAnexo != null && System.IO.Directory.Exists(rutaPosible)) //si nuestra antigua candidatura tiene algun curriculum subido y la ruta existe
                    {
                        var rutaExistente = System.IO.Path.Combine(ruta, becarioIdString, becario.NombreAnexo); // definimos la ruta hasta el nombre del curriculum anterior
                        if (System.IO.File.Exists(rutaExistente)) // comprobamos si este archivo existe por si hubiera habido anteriormente un fallo a mitad del procedimiento y se hubiese creado la carpeta pero no el archivo
                        {
                            System.IO.File.Delete(rutaExistente); // borramos el curriculum antiguo
                        }
                    }
                    var rutaNuevoFichero = System.IO.Path.Combine(rutaPosible, nombreAnexo); // ahora definimos la ruta con el nombre del fichero de nuestro nuevo cv
                    System.IO.Directory.CreateDirectory(rutaPosible); // creamos el subdirectorio con el nombre de becarioId (si ya existia no hara nada)
                    using (System.IO.FileStream fs = System.IO.File.Create(rutaNuevoFichero)) // creamos un file stream para crear nuestro nuevo fichero
                    {
                        foreach (byte i in anexo)
                        {
                            fs.WriteByte(i); //recorremos byte a byte nuestro anexo enviado y lo escribimos en la ruta especificada
                        }
                    }
                    becario.Anexo = null; // Eliminar cuando el anexo se almacene por ruta en BD
                    becario.NombreAnexo = nombreAnexo;
                    becario.UrlAnexo = ruta;
                    _becarioRepository.Update(becario);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Failed to access the becario";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public EditBecarioResponse SaveEditBecario(CreateEditBecarioViewModel viewModel)
        {
            var response = new EditBecarioResponse();
            string emails = "";

            try
            {

                var becario = _becarioRepository.GetOne(x => x.BecarioId == viewModel.BecarioId);
                var candidatura = _candidaturaRepository.GetOne(x => x.CandidatoId == becario.CandidatoId);
                //comprobamos si tenemos que actualizar la nueva necesidad


                //mappear
                becario.UpdateBecarioModoEdit(viewModel);
                if (viewModel.BecarioObservaciones != null)
                {
                    viewModel.BecarioObservaciones.BecarioId = (int)viewModel.BecarioId;
                    SaveListaObservaciones(viewModel.BecarioObservaciones);
                }

                if (candidatura != null) {
                    if (viewModel.BecarioDatosBasicos.ListEmailReferenciados != null)
                    {
                        foreach (string emailRef in viewModel.BecarioDatosBasicos.ListEmailReferenciados)
                        {
                            if (emailRef != "")
                            {
                                emails = string.Concat(emails, emailRef, ";");
                            }
                        }
                    }
                    candidatura.OrigenCvId = viewModel.BecarioDatosBasicos.OrigenCvId;
                    candidatura.FuenteReclutamientoId = viewModel.BecarioDatosBasicos.FuenteReclutamientoId;
                    candidatura.EmailsReferenciados = emails;
                    _candidaturaRepository.Update(candidatura);
                }

                //guardar
                if (_becarioRepository.Update(becario) > 0)
                {
                    response.IsValid = true;
                    //se le crea la bitacora para guardar que se ha editado
                    var bitacoraResponse = _bitacoraBecarioService.GenerateBitacoraEditBecario(becario.BecarioId);
                    response.IsValid = bitacoraResponse.IsValid;
                    response.ErrorMessage = bitacoraResponse.ErrorMessage;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to update Becario";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public bool CheckBecasAbiertas(int candidatoId)
        {
            var query = _becarioRepository.Find(x => x.IsActivo && x.CandidatoId == candidatoId &&
                                                    x.TipoEstadoBecarioId != (int)TipoEstadoBecarioEnum.Descartado
                                                    && x.TipoEstadoBecarioId != (int)TipoEstadoBecarioEnum.Finalizado
                                                    && x.TipoEstadoBecarioId != (int)TipoEstadoBecarioEnum.Renuncia);

            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public BacktrackBecarioResponse BacktrackBecario(int becarioId)
        {
            var response = new BacktrackBecarioResponse();

            try
            {
                var bitacorasRevertibles = _bitacoraBecarioRepository.GetByCriteria(x => x.BecarioId == becarioId && x.TipoBitacora.HasValue && x.Revertible.HasValue && x.Revertible.Value);

                bitacorasRevertibles = bitacorasRevertibles.OrderByDescending(x => x.BitacoraId);
                var bitacoraARevertir = bitacorasRevertibles.FirstOrDefault();

                if (bitacoraARevertir != null)
                {
                    var becario = _becarioRepository.GetOne(x => x.BecarioId == becarioId);

                    if (becario != null)
                    {
                        if (bitacoraARevertir.EstadoAnteriorId.HasValue)
                        {
                            becario.TipoEstadoBecarioId = bitacoraARevertir.EstadoAnteriorId.Value;
                        }

                        _becarioRepository.Update(becario);

                        bitacoraARevertir.Revertible = false;
                        _bitacoraBecarioRepository.Update(bitacoraARevertir);

                        _bitacoraBecarioService.GenerateBitacoraBecarioRetroceder(becario.BecarioId, bitacoraARevertir.BitacoraId);
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

        public DownloadCVResponse DownloadCV(int becarioId)
        {
            BecarioCvHelper relacionBecarioIdCv = new BecarioCvHelper();

            return relacionBecarioIdCv.GetCVBecarioByBecarioId(_becarioRepository, becarioId);
        }

        public DownloadAnexoResponse DownloadAnexo(int becarioId)
        {
            BecarioAnexoHelper relacionBecarioIdAnexo = new BecarioAnexoHelper();

            return relacionBecarioIdAnexo.GetAnexoBecarioByBecarioId(_becarioRepository, becarioId);
        }

        public GetBecariosEstadoDescartadoResponse GetBecariosEstadoDescartado()
        {
            var response = new GetBecariosEstadoDescartadoResponse();
            try
            {
                var becarios = _becarioRepository.GetByCriteria(x => x.TipoEstadoBecarioId == (int)TipoEstadoBecarioEnum.Descartado && x.TipoBecarioId == (int)TipoBecaEnum.BecaInterna && x.NotificarDescarte && x.IsActivo);

                response.BecarioRowViewModel = BecarioMapper.ConvertToBecarioRowViewModel(becarios);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetCentroBecarioResponse GetCentroBecario(int becarioId)
        {
            var response = new GetCentroBecarioResponse();

            try
            {
                var usuario = _becarioRepository.GetOne(x => x.BecarioId == becarioId).Usuario;
                if(usuario.Centro != null)
                {
                    response.NombreCentro = usuario.Centro.Nombre.Replace(System.Environment.NewLine, "");
                    response.CentroId = usuario.Centro.CentroId;
                }
                else
                {
                    response.NombreCentro = string.Empty;
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

        public GetEmailBecarioResponse GetEmailBecario(int becarioId, int tipoMedioContactoEmail)
        {
            var response = new GetEmailBecarioResponse();

            try
            {
                var becarioCandidatoId = _becarioRepository.GetOne(x => x.BecarioId == becarioId && x.IsActivo).CandidatoId;
                var email = _candidatoContactoRepository.GetOne(x => x.CandidatoId == becarioCandidatoId && x.IsActivo && x.TipoMedioContactoId == tipoMedioContactoEmail).Contacto;
                if (email != null)
                {
                    response.IsValid = true;
                    response.EmailBecario = email;
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

        #region Private Methods

        private void SaveListaObservaciones(BecarioObservacionesViewModel viewModel)
        {
            if (viewModel.BecarioObservacionList != null)
            {
                foreach (var becarioObservacionViewModel in viewModel.BecarioObservacionList)
                {
                    becarioObservacionViewModel.BecarioId = viewModel.BecarioId;
                    var becarioObservacion = _becarioObservacionRepository.GetOne(x => x.BecarioObservacionId == becarioObservacionViewModel.ObservacionId);
                    if (becarioObservacion == null)
                    {
                        becarioObservacion = new BecarioObservacion();
                    }
                    becarioObservacion.UpdateObservacion(becarioObservacionViewModel);
                    if (becarioObservacion.BecarioObservacionId != 0)
                    {
                        _becarioObservacionRepository.Update(becarioObservacion);
                    }
                    else
                    {
                        _becarioObservacionRepository.Create(becarioObservacion);
                    }
                }
            }
            if (viewModel.ObservacionesBorradas != null && viewModel.ObservacionesBorradas.Length > 0)
            {

                foreach (var id in viewModel.ObservacionesBorradas)
                {
                    if (id != "")
                    {
                        var idsBorrarParsed = id.Split(',').Select(x => int.Parse(x.Trim()));
                        foreach (var idBorrar in idsBorrarParsed)
                        {
                            var observacionBorrar = _becarioObservacionRepository.GetOne(x => x.BecarioObservacionId == idBorrar);
                            observacionBorrar.IsActivo = false;
                            _becarioObservacionRepository.Update(observacionBorrar);
                        }
                    }
                }
            }
        }

        private IQueryable<Becario> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _becarioRepository.GetAll();

            // Solo devolvemos becarios activos.
            query = query.Where(x => x.IsActivo);


            if (customFilter.ContainsKey("BecarioId") && (customFilter["BecarioId"] != string.Empty))
            {
                    var becarioId = Convert.ToInt32(customFilter["BecarioId"]);
                    query = query.Where(x => x.BecarioId == becarioId);
            }
            if (customFilter.ContainsKey("NombreBecario") && (customFilter["NombreBecario"] != string.Empty))
            {
                    var candidato = customFilter["NombreBecario"];
                    var candidatoPalabras = candidato.Split(' ');
                    foreach (string palabra in candidatoPalabras)
                    {
                        if (palabra != "")
                        {
                            query = query.Where(x => (x.Candidato.Nombre + " " + x.Candidato.Apellidos).Contains(palabra.Trim()));
                        }
                    }
            }
            if (customFilter.ContainsKey("CandidatoId") && (customFilter["CandidatoId"] != string.Empty))
            {
                    var candidatoId = Convert.ToInt32(customFilter["CandidatoId"]);
                    query = query.Where(x => x.CandidatoId == candidatoId);
            }
            if (customFilter.ContainsKey("TipoBecario") && (customFilter["TipoBecario"] != string.Empty))
            {
                    var tipoBecario = Convert.ToInt32(customFilter["TipoBecario"]);
                    query = query.Where(x => x.TipoBecarioId == tipoBecario);
            }
            if (customFilter.ContainsKey("TipoEstadoBecario[]") && (customFilter["TipoEstadoBecario[]"] != string.Empty))
            {
                    var ids = customFilter["TipoEstadoBecario[]"].Split(',').Select(x => int.Parse(x.Trim()));
                    query = query.Where(x => ids.Contains(x.TipoEstadoBecarioId));
            }

            if (customFilter.ContainsKey("TipoEstadoBecario") && (customFilter["TipoEstadoBecario"] != null && customFilter["TipoEstadoBecario"] != string.Empty))
            {
                    var estados = customFilter["TipoEstadoBecario"].Split(',').Select(x => int.Parse(x.Trim()));
                    query = query.Where(x => estados.Contains(x.TipoEstadoBecarioId));
            }
            if (customFilter.ContainsKey("CentroProcedencia") && (customFilter["CentroProcedencia"] != string.Empty))
            {
                    var centroProcedencia = Convert.ToInt32(customFilter["CentroProcedencia"]);
                    query = query.Where(x => x.BecarioCentroProcedencia.BecarioCentroProcedenciaId == centroProcedencia);
            }
            if (customFilter.ContainsKey("Cliente") && (customFilter["Cliente"] != string.Empty))
            {
                    var cliente = Convert.ToInt32(customFilter["Cliente"]); 
                    query = query.Where(x => x.ClienteId == cliente);
            }
            if (customFilter.ContainsKey("Proyecto") && (customFilter["Proyecto"] != string.Empty))
            {
                    var proyecto = Convert.ToInt32(customFilter["Proyecto"]); 
                    query = query.Where(x => x.ProyectoId == proyecto);
            }

            if (customFilter.ContainsKey("FechaInicio") && (customFilter["FechaInicio"] != string.Empty))
            {
                    var fechaInicio = Convert.ToDateTime(customFilter["FechaInicio"]);
                    query = query.Where(x => x.FechaBecaInicio >= fechaInicio);
            }

            if (customFilter.ContainsKey("FechaFin") && (customFilter["FechaFin"] != string.Empty))
            {
                    var fechaFin = Convert.ToDateTime(customFilter["FechaFin"]);
                    query = query.Where(x => x.FechaBecaFin <= fechaFin);
            }
            if (customFilter.ContainsKey("FechaFinReal") && (customFilter["FechaFinReal"] != string.Empty))
            {
                    var fechaFinReal = Convert.ToDateTime(customFilter["FechaFinReal"]);
                    query = query.Where(x => x.FechaBecaFinReal <= fechaFinReal);
            }

            if (customFilter.ContainsKey("TipoDecisionFinalId") && (customFilter["TipoDecisionFinalId"] != string.Empty))
            {
                    var tipoDecisionFinalId = Convert.ToInt32(customFilter["TipoDecisionFinalId"]);
                    query = query.Where(x => x.TipoDecisionFinalId == tipoDecisionFinalId);
            }

            if (customFilter.ContainsKey("GestionDocumentalCompleta") && (customFilter["GestionDocumentalCompleta"] != string.Empty))
            {
                    var gestionDocumentalCompleta = Convert.ToBoolean(customFilter["GestionDocumentalCompleta"]);
                    query = query.Where(x => x.CompletadoGestion == gestionDocumentalCompleta);
            }
            if (customFilter.ContainsKey("Convocatoria") && (customFilter["Convocatoria"] != string.Empty && customFilter["Convocatoria"] != null))
            {
                    var convocatoria = Convert.ToInt32(customFilter["Convocatoria"]);
                    query = query.Where(x => x.BecarioConvocatoriaId == convocatoria);
            }

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

            if (customFilter.ContainsKey("NivelIdioma") && customFilter["NivelIdioma"] != string.Empty)
            {
                var nivelIdiomaId = Convert.ToInt32(customFilter["NivelIdioma"]);
                query = query.Where(x => x.Candidato.CandidatoIdiomas.Any(y => y.NivelIdiomaId >= nivelIdiomaId && y.IdiomaId == 15));
            }


            return query;
        }

        #endregion
    }
}
