using Recruiting.Application.Becarios.Enums;
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Helpers;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Becarios.Mappers
{
    public static class BecarioMapper
    {
        #region Mapper
        public static IEnumerable<BecarioRowViewModel> ConvertToBecarioRowViewModel(this IEnumerable<Becario> becarioList)
        {
            var becarioRowViewModelList = new List<BecarioRowViewModel>();

            if (becarioList == null)
            {
                return becarioRowViewModelList;
            }

            becarioRowViewModelList = becarioList.Select(x => x.ConvertToBecarioRowViewModel()).ToList();

            return becarioRowViewModelList;
        }

        public static BecarioRowViewModel ConvertToBecarioRowViewModel(this Becario becario)
        {
            string NivelIngles = "N/A";

            foreach(CandidatoIdioma idioma in becario.Candidato.CandidatoIdiomas) {
                if (idioma.IdiomaId == 15) {
                    NivelIngles = idioma.NivelIdioma.Nombre;
                }
            }

            var clienteRowViewModel = new BecarioRowViewModel()
            {
                BecarioId = becario.BecarioId,
                BecarioNombre = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos,
                CandidatoId = becario.CandidatoId,
                TipoBecarioId = becario.TipoBecarioId,
                TipoBecario = becario.TipoBecario.Nombre,
                EstadoBecarioId = becario.TipoEstadoBecarioId,
                EstadoBecario = becario.TipoEstadoBecario.EstadoBecario,
                CentroProcedencia = becario.BecarioCentroProcedenciaId == null ? "" : becario.BecarioCentroProcedencia.Centro,
                Convocatoria = becario.BecarioConvocatoriaId == null ? "" : becario.BecarioConvocatoria.NombreConvocatoria,
                FechaInicio = becario.FechaBecaInicio.HasValue ? becario.FechaBecaInicio.Value.Day + "/" + becario.FechaBecaInicio.Value.Month + "/" + becario.FechaBecaInicio.Value.Year : "",
                FechaFin = becario.FechaBecaFin.HasValue ? becario.FechaBecaFin.Value.Day + "/" + becario.FechaBecaFin.Value.Month + "/" + becario.FechaBecaFin.Value.Year : "",
                FechaFinReal = becario.FechaBecaFinReal.HasValue ? becario.FechaBecaFinReal.Value.Day + "/" + becario.FechaBecaFinReal.Value.Month + "/" + becario.FechaBecaFinReal.Value.Year : "",
                Cliente = becario.Cliente == null ? "" : becario.Cliente.Nombre,
                Proyecto = becario.Proyecto == null ? "" : becario.Proyecto.Nombre,
                NivelIdioma = NivelIngles,
                TipoDecisionFinal = becario.TipoDecisionFinal != null ? becario.TipoDecisionFinal.Nombre : null,
                TipoDecisionFinalId = becario.TipoDecisionFinalId


            };
           

            return clienteRowViewModel;
        }

        public static IEnumerable<BecarioRowExportToExcelViewModel> ConvertToBecarioRowExportToExcelViewModel(this IEnumerable<Becario> becarioList)
        {
            var becarioRowExportToExcelViewModelList = new List<BecarioRowExportToExcelViewModel>();

            if (becarioList == null) return becarioRowExportToExcelViewModelList;

            becarioRowExportToExcelViewModelList = becarioList.Select(x => x.ConvertToBecarioRowExportToExcelViewModel()).ToList();

            return becarioRowExportToExcelViewModelList;
        }


        public static CandidatoQueCumplePerfilRowViewModel ConvertToCandidatoQueCumplePerfilRowViewModel(Candidato candidato, int candidaturaId)
        {
            var vieModel = new CandidatoQueCumplePerfilRowViewModel()
            {
                Nombre = candidato.Nombre,
                Apellidos = candidato.Apellidos,
                CandidatoId = candidato.CandidatoId,
                NumeroIdentificacion = candidato.NumeroIdentificacion,
                candidaturaIdAsociado = candidaturaId,
                Centro = candidato.Usuario.CentroId != null ? candidato.Usuario.Centro.Nombre : string.Empty
            };

            return vieModel;
        }

        public static IEnumerable<CandidatoRowViewModel> ConvertToCandidatoRowViewModel(this IDictionary<Candidato, int> relacionCandidatoCandituras, List<int> candidatosNoPuedenCandidatura)
        {
            var candidatoRowViewModelList = new List<CandidatoRowViewModel>();

            var response = (relacionCandidatoCandituras == null)
                ? candidatoRowViewModelList
                : relacionCandidatoCandituras.Select(x => x.Key.ConvertToCandidatoRowViewModel(x.Value, candidatosNoPuedenCandidatura)).ToList();

            return response;

        }

        public static IEnumerable<CandidatoRowViewModel> ConvertToCandidatoRowViewModel(this IEnumerable<Candidato> candidatosFiltrados)
        {
            var candidatoRowViewModelList = new List<CandidatoRowViewModel>();

            var response = (candidatosFiltrados == null)
                ? candidatoRowViewModelList
                : candidatosFiltrados.Select(x => x.ConvertToCandidatoRowViewModel(null, null)).ToList();

            return response;

        }         

        public static CreateEditBecarioViewModel ConvertToCreateEditBecarioViewModel(this Becario becario)
        {

            return new CreateEditBecarioViewModel()
            {
                BecarioId = becario.BecarioId,
                Activo = becario.IsActivo,
                BecarioDatosBasicos = becario.ConvertToBecarioDatosBasicosViewModel(),
                BecarioObservaciones = becario.ConvertToBecarioObservacionesViewModel(),
                BecarioSeleccion = becario.ConvertToBecarioSeleccionViewModel(),
                BecarioDatosPracticas = becario.ConvertToBecarioDatosPracticasViewModel(),
                ComentariosRenuncia = becario.ComentarioRenunciaDescarte
            };
        }

        private static BecarioDatosBasicosViewModel ConvertToBecarioDatosBasicosViewModel(this Becario becario)
        {

            var emails = new List<string>();

            if (becario.EmailsReferenciados != null)
            {
                emails = becario.EmailsReferenciados.Split(';').ToList();
            }

            if (emails.Count > 0 && emails.Last() == "")
            {
                emails.RemoveAt(emails.Count - 1);
            }

            var BecarioDatosBasicosViewModel = new BecarioDatosBasicosViewModel()
            {
                BecarioId = becario.BecarioId,
                CandidatoId = becario.CandidatoId,
                TipoBecarioId = becario.TipoBecarioId,
                TipoBecario = becario.TipoBecario.Nombre,
                EstadoBecarioId = becario.TipoEstadoBecarioId,
                NombreCandidato = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos,
                NombreCentroProcedencia = becario.BecarioCentroProcedenciaId == null ? null : becario.BecarioCentroProcedencia.Centro,
                CentroProcedenciaId = becario.BecarioCentroProcedenciaId,
                ConvocatoriaId = becario.BecarioConvocatoriaId,
                NombreConvocatoria = becario.BecarioConvocatoriaId == null ? null : becario.BecarioConvocatoria.NombreConvocatoria,
                NombreCV = becario.NombreCV,
                CV = becario.CV,
                UrlCV = becario.UrlCV,
                SubidoCv = (becario.NombreCV != null),
                OrigenCvId = becario.OrigenCvId,
                OrigenCvNombre = becario.OrigenCv == null ? "" : becario.OrigenCv.Nombre,
                FuenteReclutamientoId = becario.FuenteReclutamientoId,
                FuenteReclutamientoNombre = becario.FuenteReclutamiento == null ? "" : becario.FuenteReclutamiento.Nombre,
                ListEmailReferenciados = emails
            };

            return BecarioDatosBasicosViewModel;
        }

        private static BecarioObservacionesViewModel ConvertToBecarioObservacionesViewModel(this Becario becario)
        {


            var BecarioObservacionesViewModel = new BecarioObservacionesViewModel()
            {
                BecarioId = becario.BecarioId,
                ObservacionGeneralProceso = becario.ObservacionFinalProceso,
                SuperaProceso = becario.SuperaProceso,
                BecarioObservacionList = becario.ConvertToBecarioObservacionesListViewModel(becario.BecarioId),
                NombreCandidato = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos
            };

            return BecarioObservacionesViewModel;
        }

        private static BecarioSeleccionViewModel ConvertToBecarioSeleccionViewModel(this Becario becario)
        {


            var BecarioSeleccionViewModel = new BecarioSeleccionViewModel()
            {
                BecarioId = becario.BecarioId,
                CompletadoGestion = becario.CompletadoGestion,
                CompletadoAsignacion = becario.CompletadoAsignacion,
                BecarioGestionDocumental = becario.ConvertToBecarioGestionDocumentalViewModel()     ,
                BecarioAsignacion = becario.ConvertToBecarioAsignacionViewModel(),
                NombreCandidato = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos
            };

            return BecarioSeleccionViewModel;
        }

        private static BecarioDatosPracticasViewModel ConvertToBecarioDatosPracticasViewModel(this Becario becario)
        {


            var BecarioDatosPracticasViewModel = new BecarioDatosPracticasViewModel()
            {
                BecarioId = becario.BecarioId,
                DecisionFinalId = becario.TipoDecisionFinalId,
                DecisionFinalNombre = becario.TipoDecisionFinalId == null ? null : becario.TipoDecisionFinal.Nombre,
                ObservacionFinalPracticas = becario.ObservacionFinalPracticas,
                NombreCandidato = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos
            };

            return BecarioDatosPracticasViewModel;
        }

        private static BecarioGestionDocumentalViewModel ConvertToBecarioGestionDocumentalViewModel(this Becario becario)
        {


            var BecarioGestionDocumentalViewModel = new BecarioGestionDocumentalViewModel()
            {
                FechaInicio = becario.FechaBecaInicio,
                FechaFin = becario.FechaBecaFin,
                FechaFinReal = becario.FechaBecaFinReal,
                NumHoras = becario.NumHoras,
                Anexo = becario.Anexo,
                NombreAnexo = becario.NombreAnexo,
                UrlAnexo = becario.UrlAnexo,
                SubidoAnexo = (becario.NombreAnexo != null),
            };

            return BecarioGestionDocumentalViewModel;
        }

        private static BecarioAsignacionViewModel ConvertToBecarioAsignacionViewModel(this Becario becario)
        {


            var BecarioAsignacionViewModel = new BecarioAsignacionViewModel()
            {
                Asistencia = becario.TipoAsistenciaId,
                AsistenciaNombre = becario.TipoAsistenciaId == null ? null : becario.TipoAsistencia.Nombre,
                Cliente = becario.ClienteId,
                ClienteNombre = becario.ClienteId == null ? null :  becario.Cliente.Nombre,
                Proyecto = becario.ProyectoId,
                ProyectoNombre = becario.ProyectoId == null ? null :  becario.Proyecto.Nombre,
                ResponsableId = becario.ResponsableId,
                ResponsableNombre = becario.ResponsableNombre,
                TutorId = becario.TutorId,
                TutorNombre = becario.TutorNombre
            };

            return BecarioAsignacionViewModel;
        }

        private static List<BecarioObservacionViewModel> ConvertToBecarioObservacionesListViewModel(this Becario becario, int becarioId)
        {
            IBecarioObservacionRepository _becarioObservacionrepository = new BecarioObservacionRepository();

            var becarioObservacionesListViewModel = new List<BecarioObservacionViewModel>();
            var becarioObservacionesList = _becarioObservacionrepository.GetByCriteria(x => x.IsActivo && x.BecarioId == becarioId);
            foreach(var observacion in becarioObservacionesList)
            {
                BecarioObservacionViewModel observacionViewModel = new BecarioObservacionViewModel()
                {
                    ObservacionId = observacion.BecarioObservacionId,
                    BecarioId = observacion.BecarioId,
                    TipoPruebaId = observacion.TipoPruebaId,
                    TipoPrueba = observacion.TipoPrueba.Nombre,
                    PersonaConvocatoriaNombre = observacion.PersonaConvocatoriaNombre,
                    PersonaConvocatoriaId = observacion.PersonaConvocatoriaId,                    
                    FechaConvocatoria = observacion.FechaConvocatoria,
                    TipoResultadoId = (int)observacion.TipoResultadoId,
                    TipoResultado = observacion.TipoResultado.Nombre,
                    Observacion = observacion.Observaciones
                };
                becarioObservacionesListViewModel.Add(observacionViewModel);
            }

            return becarioObservacionesListViewModel;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "BecarioId":
                    attributeName = "BecarioId";
                    break;
                case "BecarioNombre":
                    attributeName = "Candidato.Nombre";
                    break;
                case "CandidatoId":
                    attributeName = "CandidatoId";
                    break;
                case "TipoBecario":
                    attributeName = "TipoBecario.Nombre";
                    break;
                case "EstadoBecario":
                    attributeName = "TipoEstadoBecario.EstadoBecario";
                    break;
                case "DecisionFinal":
                    attributeName = "TipoDecisionFinalId";
                    break;
                case "Cliente":
                    attributeName = "Cliente.Nombre";
                    break;
                case "Proyecto":
                    attributeName = "Proyecto.Nombre";
                    break;
                case "FechaInicio":
                    attributeName = "FechaBecaInicio";
                    break;
                case "FechaFin":
                    attributeName = "FechaBecaFin";
                    break;
                case "FechaFinReal":
                    attributeName = "FechaBecaFinReal";
                    break;

            }

            return attributeName;
        }

        public static void UpdateBecario(this Becario becario, BecarioDatosBasicosViewModel becarioDatosBasicosViewModel)
        {

            if (becarioDatosBasicosViewModel.BecarioId != null)
            {
                becario.BecarioId = (int)becarioDatosBasicosViewModel.BecarioId;

                becario.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                becario.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                becario.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                becario.Created = ModifiableEntityHelper.GetCurrentDate();

                becario.TipoEstadoBecarioId = (int)TipoEstadoBecarioEnum.Inicio;                
            }
                   
            becario.CandidatoId = becarioDatosBasicosViewModel.CandidatoId;  
            becario.CV = becarioDatosBasicosViewModel.CV;
            becario.NombreCV = becarioDatosBasicosViewModel.NombreCV;            
            becario.UrlCV = becarioDatosBasicosViewModel.UrlCV;
            becario.IsActivo = true;
            becario.TipoBecarioId = becarioDatosBasicosViewModel.TipoBecarioId;
            becario.BecarioCentroProcedenciaId = becarioDatosBasicosViewModel.CentroProcedenciaId;
            becario.BecarioConvocatoriaId = (int)becarioDatosBasicosViewModel.ConvocatoriaId;
            becario.OrigenCvId = becarioDatosBasicosViewModel.OrigenCvId;
            becario.FuenteReclutamientoId = becarioDatosBasicosViewModel.FuenteReclutamientoId;
            becario.EmailsReferenciados = ConvertEmailRefListToString(becarioDatosBasicosViewModel.ListEmailReferenciados);

        }    

        public static void UpdateBecario(this Becario becario, BecarioObservacionesViewModel becarioObservacionesViewModel)
        {
           
            becario.BecarioId = becarioObservacionesViewModel.BecarioId;

            becario.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            becario.Modified = ModifiableEntityHelper.GetCurrentDate();
            becario.ObservacionFinalProceso = becarioObservacionesViewModel.ObservacionGeneralProceso;
            becario.SuperaProceso = becarioObservacionesViewModel.SuperaProceso;          

        }

        public static void UpdateBecario(this Becario becario, BecarioSeleccionViewModel becarioSeleccionViewModel)
        {

            becario.BecarioId = (int)becarioSeleccionViewModel.BecarioId;

            becario.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            becario.Modified = ModifiableEntityHelper.GetCurrentDate();
            becario.CompletadoGestion = becarioSeleccionViewModel.CompletadoGestion;
            becario.CompletadoAsignacion = becarioSeleccionViewModel.CompletadoAsignacion;

            if(becarioSeleccionViewModel.BecarioGestionDocumental != null)
            {
                becario.FechaBecaInicio = becarioSeleccionViewModel.BecarioGestionDocumental.FechaInicio;
                becario.FechaBecaFin = becarioSeleccionViewModel.BecarioGestionDocumental.FechaFin;
                becario.FechaBecaFinReal = becarioSeleccionViewModel.BecarioGestionDocumental.FechaFinReal;
                becario.NumHoras = becarioSeleccionViewModel.BecarioGestionDocumental.NumHoras;
                if (becarioSeleccionViewModel.BecarioGestionDocumental.NombreAnexo != null)
                {
                    becario.NombreAnexo = becarioSeleccionViewModel.BecarioGestionDocumental.NombreAnexo;
                    becario.Anexo = becarioSeleccionViewModel.BecarioGestionDocumental.Anexo;
                    becario.UrlAnexo = becarioSeleccionViewModel.BecarioGestionDocumental.UrlAnexo;
                }                
            }
            if (becarioSeleccionViewModel.BecarioAsignacion != null)
            {
                becario.TipoAsistenciaId = becarioSeleccionViewModel.BecarioAsignacion.Asistencia;
                becario.ClienteId = becarioSeleccionViewModel.BecarioAsignacion.Cliente;
                becario.ProyectoId = becarioSeleccionViewModel.BecarioAsignacion.Proyecto;
                becario.ResponsableId = becarioSeleccionViewModel.BecarioAsignacion.ResponsableId;
                becario.ResponsableNombre = becarioSeleccionViewModel.BecarioAsignacion.ResponsableNombre;
                becario.TutorId = becarioSeleccionViewModel.BecarioAsignacion.TutorId;
                becario.TutorNombre = becarioSeleccionViewModel.BecarioAsignacion.TutorNombre;
            }

        }

        public static void UpdateBecario(this Becario becario, BecarioDatosPracticasViewModel becarioDatosPracticasViewModel)
        {            
            becario.BecarioId = (int)becarioDatosPracticasViewModel.BecarioId;

            becario.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            becario.Modified = ModifiableEntityHelper.GetCurrentDate();

            becario.TipoDecisionFinalId = becarioDatosPracticasViewModel.DecisionFinalId;
            becario.ObservacionFinalPracticas = becarioDatosPracticasViewModel.ObservacionFinalPracticas;

        }

        public static void UpdateObservacion(this BecarioObservacion observacion, BecarioObservacionViewModel becarioObservacionViewModel)
        {
            if (becarioObservacionViewModel.ObservacionId != null)
            {
                observacion.BecarioObservacionId = (int)becarioObservacionViewModel.ObservacionId;

                observacion.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                observacion.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {                
                observacion.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                observacion.Created = ModifiableEntityHelper.GetCurrentDate();

            }

            observacion.BecarioId = becarioObservacionViewModel.BecarioId;
            observacion.TipoPruebaId = becarioObservacionViewModel.TipoPruebaId;
            observacion.PersonaConvocatoriaNombre = becarioObservacionViewModel.PersonaConvocatoriaNombre;
            observacion.PersonaConvocatoriaId = becarioObservacionViewModel.PersonaConvocatoriaId;           
            observacion.FechaConvocatoria = becarioObservacionViewModel.FechaConvocatoria;
            observacion.Observaciones = becarioObservacionViewModel.Observacion;
            observacion.TipoResultadoId = becarioObservacionViewModel.TipoResultadoId;
            observacion.IsActivo = true;
            

        }

        public static void UpdateBecarioModoEdit(this Becario becario, CreateEditBecarioViewModel becarioViewModel)
        {
            becario.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            becario.Modified = ModifiableEntityHelper.GetCurrentDate();

            if (becarioViewModel.BecarioDatosBasicos != null)
            {
                //se actualiza salvo el candidato que no se puede cambiar ni los estados que no deben cambiar 
                //ni los ids  
                becario.CandidatoId = becarioViewModel.BecarioDatosBasicos.CandidatoId;                
                becario.UrlCV = becarioViewModel.BecarioDatosBasicos.UrlCV ?? becario.UrlCV;
                becario.CV = becarioViewModel.BecarioDatosBasicos.CV ?? becario.CV;
                becario.NombreCV = becarioViewModel.BecarioDatosBasicos.NombreCV ?? becario.NombreCV;
                becario.TipoBecarioId = becarioViewModel.BecarioDatosBasicos.TipoBecarioId;
                becario.BecarioCentroProcedenciaId = becarioViewModel.BecarioDatosBasicos.CentroProcedenciaId;
                becario.BecarioConvocatoriaId = (int)becarioViewModel.BecarioDatosBasicos.ConvocatoriaId;
                becario.OrigenCvId = becarioViewModel.BecarioDatosBasicos.OrigenCvId;
                becario.FuenteReclutamientoId = becarioViewModel.BecarioDatosBasicos.FuenteReclutamientoId;
                becario.EmailsReferenciados = ConvertEmailRefListToString(becarioViewModel.BecarioDatosBasicos.ListEmailReferenciados);
            }

            if (becarioViewModel.BecarioObservaciones != null)
            {
                becario.SuperaProceso = becarioViewModel.BecarioObservaciones.SuperaProceso;
                becario.ObservacionFinalProceso = becarioViewModel.BecarioObservaciones.ObservacionGeneralProceso;
               
            }

            if(becarioViewModel.BecarioSeleccion != null)
            {
                becario.CompletadoAsignacion = becarioViewModel.BecarioSeleccion.CompletadoAsignacion;
                becario.CompletadoGestion = becarioViewModel.BecarioSeleccion.CompletadoGestion;
                if(becarioViewModel.BecarioSeleccion.BecarioGestionDocumental != null)
                {
                    becario.FechaBecaInicio = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.FechaInicio;
                    becario.FechaBecaFin = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.FechaFin;
                    becario.FechaBecaFinReal = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.FechaFinReal;
                    becario.NumHoras = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.NumHoras;
                    becario.Anexo = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.Anexo ?? becario.Anexo;
                    becario.NombreAnexo = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.NombreAnexo ?? becario.NombreAnexo;
                    becario.UrlAnexo = becarioViewModel.BecarioSeleccion.BecarioGestionDocumental.UrlAnexo ?? becario.UrlAnexo;
                }
                if (becarioViewModel.BecarioSeleccion.BecarioGestionDocumental != null)
                {
                    becario.TipoAsistenciaId = becarioViewModel.BecarioSeleccion.BecarioAsignacion.Asistencia;
                    becario.ClienteId = becarioViewModel.BecarioSeleccion.BecarioAsignacion.Cliente;
                    becario.ProyectoId = becarioViewModel.BecarioSeleccion.BecarioAsignacion.Proyecto;
                    becario.ResponsableId = becarioViewModel.BecarioSeleccion.BecarioAsignacion.ResponsableId;
                    becario.ResponsableNombre = becarioViewModel.BecarioSeleccion.BecarioAsignacion.ResponsableNombre;
                    becario.TutorId = becarioViewModel.BecarioSeleccion.BecarioAsignacion.TutorId;
                    becario.TutorNombre = becarioViewModel.BecarioSeleccion.BecarioAsignacion.TutorNombre;               
                }
            }
            if(becarioViewModel.BecarioDatosPracticas != null)
            {
                becario.ObservacionFinalPracticas = becarioViewModel.BecarioDatosPracticas.ObservacionFinalPracticas;
                becario.TipoDecisionFinalId = becarioViewModel.BecarioDatosPracticas.DecisionFinalId;
            }

            becario.ComentarioRenunciaDescarte = becarioViewModel.ComentariosRenuncia;
        }

        #region Private Methods
        private static string ConvertEmailRefListToString( List<string> emailsList) {
            string emails = "";

            if (emailsList != null)
            {
                foreach (string emailRef in emailsList)
                {
                    if (emailRef != "")
                    {
                        emails = string.Concat(emails, emailRef, ";");
                    }
                }
            }

            return emails;
        }

        private static CandidatoRowViewModel ConvertToCandidatoRowViewModel(this Candidato candidato, int? numCandidaturasAsociadas, List<int> candidatosNoPuedenCandidatura)
        {
            var vieModel = new CandidatoRowViewModel()
            {
                Apellidos = candidato.Apellidos,
                CandidatoId = candidato.CandidatoId,
                FechaNacimiento = candidato.FechaNacimiento,
                Nombres = candidato.Nombre,
                NumeroIdentificacion = candidato.NumeroIdentificacion,
                NumCandidaturasAsociadas = numCandidaturasAsociadas,
                Titulacion = candidato.Titulacion.Nombre,
                CVAvailable = false,
                CandidaturaAvailable = true,
                Centro = candidato.Usuario.CentroId != null ? candidato.Usuario.Centro.Nombre : string.Empty
            };

            vieModel.CandidaturaAvailable = (candidatosNoPuedenCandidatura != null) && !candidatosNoPuedenCandidatura.Contains(candidato.CandidatoId);

            return vieModel;
        }

        private static BecarioRowExportToExcelViewModel ConvertToBecarioRowExportToExcelViewModel(this Becario becario)
        {
            var NivelIngles = "N/A";

            foreach(CandidatoIdioma idioma in becario.Candidato.CandidatoIdiomas) {
                if (idioma.IdiomaId == 15) {
                    NivelIngles = idioma.NivelIdioma.Nombre;
                }
            }

            var vieModel = new BecarioRowExportToExcelViewModel()
            {
                BecarioId = becario.BecarioId,
                NombreBecario = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos,
                CandidatoId = becario.CandidatoId,
                TipoBecario = becario.TipoBecario.Nombre,
                TipoBecarioEstado = becario.TipoEstadoBecario.EstadoBecario,
                TipoDecisionFinal = becario.TipoDecisionFinal != null ? becario.TipoDecisionFinal.Nombre : null,
                CentroProcedencia = becario.BecarioCentroProcedencia == null ? "" : becario.BecarioCentroProcedencia.Centro,
                Convocatoria = becario.BecarioConvocatoria == null ? "" : becario.BecarioConvocatoria.NombreConvocatoria,
                Cliente = becario.Cliente != null ? becario.Cliente.Nombre : "",
                Proyecto = becario.Proyecto != null ? becario.Proyecto.Nombre : "",
                FechaInicio = becario.FechaBecaInicio,
                FechaFin = becario.FechaBecaFin,
                FechaFinReal = becario.FechaBecaFinReal,
                NivelIngles = NivelIngles

            };          

            return vieModel;
        }

        #endregion

        #endregion
    }
}
