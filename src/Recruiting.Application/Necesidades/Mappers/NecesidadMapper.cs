using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Recruiting.Application.Necesidades.Mappers
{
    public static class NecesidadMapper
    {
        #region Mapper

        public static IEnumerable<NecesidadRowViewModel> ConvertToNecesidadViewModel(this IEnumerable<Necesidad> necesidadList)
        {
            var necesidadRowViewModelList = new List<NecesidadRowViewModel>();

            if (necesidadList == null)
            {
                return necesidadRowViewModelList;
            }

            necesidadRowViewModelList = necesidadList.Select(x => x.ConvertToNecesidadRowViewModel()).ToList();

            return necesidadRowViewModelList;
        }
        public static NecesidadRowViewModel ConvertToNecesidadRowViewModel(this Necesidad necesidad)
        {
            var necesidadRowViewModel = new NecesidadRowViewModel
            {
                NecesidadId = necesidad.NecesidadId,
                Cliente = necesidad.Proyecto.Cliente.Nombre,
                Proyecto = necesidad.Proyecto.Nombre,
                FechaCreacion = necesidad.Created,
                FechaModificacion = necesidad.Modified.HasValue ? (DateTime)necesidad.Modified : DateTime.MinValue ,
                Tecnologia = necesidad.TipoTecnologia.Nombre,
                Perfil = necesidad.TipoPerfil.Nombre,
                Estado = necesidad.EstadoNecesidad.Nombre,
                FechaSolicitud = necesidad.FechaSolicitud,
                FechaCompromiso = necesidad.FechaCompromiso.Value,
                Nombre = necesidad.Nombre,
                TipoPrevisionId = necesidad.TipoPrevision.Nombre,
                Centro = necesidad.Centro.Nombre,
                PersonaAsignada = necesidad.GetPersonaAsignada(),
                Modulo = necesidad.Modulo,
                TipoContratacion = necesidad.TipoContratacion.Nombre                

            };
            if (necesidad.FechaCierre.HasValue)
            {
                necesidadRowViewModel.FechaCierre = (DateTime)necesidad.FechaCierre;
            }
            if ((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada
                || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                && necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
            {
                necesidadRowViewModel.PersonaAsignadaId = necesidad.PersonaAsignadaId;
                necesidadRowViewModel.PersonaAsignadaNroEmpleado = necesidad.PersonaAsignadaNroEmpleado;
            }
            else if ((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada
                || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                && necesidad.TipoContratacionId == (int)TipoContratacionEnum.Contratación)
            {
                necesidadRowViewModel.PersonaAsignadaId = necesidad.PersonaAsignadaId;
                necesidadRowViewModel.PersonaAsignadaNroEmpleado = null;
            }
            if (necesidad.AsignadaCorrectamente.HasValue)
            {
                necesidadRowViewModel.AsignadaCorrectamente = (necesidad.AsignadaCorrectamente.Value) ? "Si": "No";
            }

            return necesidadRowViewModel;
        }

        public static IEnumerable<StaffingNecesidadRowViewModel> ConvertToStaffingNecesidadViewModel(this IEnumerable<Necesidad> necesidadList)
        {
            var staffingNecesidadRowViewModelList = new List<StaffingNecesidadRowViewModel>();

            if (necesidadList == null)
            {
                return staffingNecesidadRowViewModelList;
            }

            staffingNecesidadRowViewModelList = necesidadList.Select(x => x.ConvertToStaffingNecesidadRowViewModel()).ToList();

            return staffingNecesidadRowViewModelList;
        }
        public static StaffingNecesidadRowViewModel ConvertToStaffingNecesidadRowViewModel(this Necesidad necesidad)
        {
            var necesidadRowViewModel = new StaffingNecesidadRowViewModel()
            {
                NecesidadId = necesidad.NecesidadId,
                Cliente = necesidad.Proyecto.Cliente.Nombre,
                Proyecto = necesidad.Proyecto.Nombre,                
                FechaCompromiso = necesidad.FechaCompromiso,
                PerfilId = necesidad.TipoPerfilId,
                Perfil = necesidad.TipoPerfil.Nombre,
                PersonaAsignada = necesidad.PersonaAsignada,
                //El siguiente id no es de la persona asignada en si sino que varia y puede ser el de la candidatura o persona libre
                PersonaAsignadaId = necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno ?
                                        necesidad.PersonaAsignadaId : necesidad.CandidaturaId,
                TecnologiaId = necesidad.TipoTecnologiaId,
                TipoContratacionId = necesidad.TipoContratacionId,
                Prioridad = necesidad.Prioridad,
                ObservacionesStaffing = necesidad.ObservacionesStaffing
            };

            return necesidadRowViewModel;
        }

        public static IEnumerable<StaffingPersonaRowViewModel> ConvertToStaffingPersonaViewModel(this IEnumerable<Candidatura> candidaturaList)
        {
            var staffingPersonaViewModelList = new List<StaffingPersonaRowViewModel>();

            if (candidaturaList == null)
            {
                return staffingPersonaViewModelList;
            }

            staffingPersonaViewModelList = candidaturaList.Select(x => x.ConvertToStaffingPersonaRowViewModel()).ToList();

            return staffingPersonaViewModelList;
        }
        public static StaffingPersonaRowViewModel ConvertToStaffingPersonaRowViewModel(this Candidatura candidatura)
        {
            var personaRowViewModel = new StaffingPersonaRowViewModel()
            {
                PersonaId = candidatura.CandidaturaId,
                NombreCompleto = candidatura.Candidato.Nombre + " " + candidatura.Candidato.Apellidos,
                TipoPersonaId = (int)TipoPersonaEnum.Candidatura,
                Categoria = candidatura.Categoria == null ? "" :  candidatura.Categoria.Nombre,
                CategoriaId = candidatura.CategoriaId,
                TipoPersona = "Candidatura"
            };

            return personaRowViewModel;
        }

        public static IEnumerable<StaffingPersonaRowViewModel> ConvertToStaffingPersonaViewModel(this IEnumerable<PersonaLibre> personaLibreList)
        {
            var staffingPersonaViewModelList = new List<StaffingPersonaRowViewModel>();

            if (personaLibreList == null)
            {
                return staffingPersonaViewModelList;
            }

            staffingPersonaViewModelList = personaLibreList.Select(x => x.ConvertToStaffingPersonaRowViewModel()).ToList();

            return staffingPersonaViewModelList;
        }
        public static StaffingPersonaRowViewModel ConvertToStaffingPersonaRowViewModel(this PersonaLibre personaLibre)
        {
            var personaRowViewModel = new StaffingPersonaRowViewModel()
            {
                PersonaId = personaLibre.PersonaLibreId,
                NombreCompleto = personaLibre.Nombre + " " + personaLibre.Apellidos,
                Categoria = personaLibre.Categoria == null ? "" : personaLibre.Categoria,
                TipoPersonaId = (int)TipoPersonaEnum.PersonaLibre,
                TipoPersona = "Persona Libre"
            };

            return personaRowViewModel;
        }


        public static NecesidadRowExportToExcelViewModel ConvertToNecesidadRowExportToExcelViewModel(this Necesidad necesidad)
        {
            var necesidadRowExportToExcelViewModel = new NecesidadRowExportToExcelViewModel
            {
                Referencia = necesidad.NecesidadId,
                Cliente = necesidad.Proyecto.Cliente.Nombre,
                Proyecto = necesidad.Proyecto.Nombre,
                Tecnologia = necesidad.TipoTecnologia.Nombre,
                Perfil = necesidad.TipoPerfil.Nombre,
                Estado = necesidad.EstadoNecesidad.Nombre,
                //FechaSolicitud = necesidad.FechaSolicitud.ToShortDateString(),
                FechaCompromiso = necesidad.FechaCompromiso.Value.ToShortDateString(),
                //Nombre = necesidad.Nombre,
                TipoPrevisionId = necesidad.TipoPrevision.Nombre,
                Centro = necesidad.Centro.Nombre,
                PersonaAsignada = necesidad.GetPersonaAsignada(),
                TipoContratacion = necesidad.TipoContratacion.Nombre,
                FechaCierre = (necesidad.FechaCierre.HasValue) ? necesidad.FechaCierre.Value.ToShortDateString() : "",
                AsignadaCorrectamente = "",
                Sector = necesidad.Sector.Nombre,
                FechaAlta = necesidad.Created.ToShortDateString()
            };

            if(necesidad.AsignadaCorrectamente.HasValue)
            {
                if(necesidad.AsignadaCorrectamente == true)
                {
                    necesidadRowExportToExcelViewModel.AsignadaCorrectamente = "Si";
                }
                else
                {
                    necesidadRowExportToExcelViewModel.AsignadaCorrectamente = "No";
                }
            }

            return necesidadRowExportToExcelViewModel;
        }

        public static NecesidadStaffingRowExportToExcelViewModel ConvertToNecesidadStaffingRowExportToExcelViewModel(this Necesidad necesidad)
        {
            var necesidadStaffingRowExportToExcelViewModel = new NecesidadStaffingRowExportToExcelViewModel
            {
                Referencia = necesidad.NecesidadId,
                Cliente = necesidad.Proyecto.Cliente.Nombre,
                Proyecto = necesidad.Proyecto.Nombre,                
                Perfil = necesidad.TipoPerfil.Nombre,                
                FechaCompromiso = necesidad.FechaCompromiso.Value.ToShortDateString(),                                
                PersonaAsignada = necesidad.GetPersonaAsignada(),
                Observaciones = necesidad.ObservacionesStaffing,
            };

            return necesidadStaffingRowExportToExcelViewModel;
        }

        public static CreateEditNecesidadViewModel ConvertToCreateEditNecesidadViewModel(this Necesidad necesidad)
        {
            var createEditNecesidadViewModel = new CreateEditNecesidadViewModel
            {
                NecesidadId = necesidad.NecesidadId,
                Nombre = necesidad.Nombre,
                OficinaId = necesidad.OficinaId,
                OficinaNombre = necesidad.Oficina?.Nombre,
                CentroId = necesidad.CentroId,
                SectorId = necesidad.SectorId,
                SectorNombre = necesidad.Sector?.Nombre,
                ClienteId = necesidad.Proyecto.ClienteId,
                ClienteNombre = necesidad.Proyecto.Cliente?.Nombre,
                ProyectoId = necesidad.ProyectoId,
                ProyectoNombre = necesidad.Proyecto?.Nombre,
                TipoServicioId = necesidad.TipoServicioId,
                TipoServicioNombre = necesidad.TipoServicio?.Nombre,
                TipoPerfilId = necesidad.TipoPerfilId,
                TipoPerfilNombre = necesidad.TipoPerfil?.Nombre,
                TipoTecnologiaId = necesidad.TipoTecnologiaId,
                TipoTecnologiaNombre = necesidad.TipoTecnologia?.Nombre,
                TipoContratacionId = necesidad.TipoContratacionId,
                TipoContratacionNombre = necesidad.TipoContratacion?.Nombre,
                TipoPrevisionId = necesidad.TipoPrevisionId,
                TipoPrevisionNombre = necesidad.TipoPrevision?.Nombre,
                MesesAsignacionId = necesidad.MesesAsignacionId,
                MesesAsignacionNombre = necesidad.MesesAsignacion?.Nombre,
                DetalleTecnologia = necesidad.Observaciones,
                DisponibilidadViajes = (necesidad.DisponibilidadViaje == true),
                DisponibilidadReubicacion = (necesidad.CambioResidencia == true),
                NecesidadIdioma = (necesidad.NecesidadIdioma == true),
                FechaSolicitud = necesidad.FechaSolicitud,
                FechaCompromiso = necesidad.FechaCompromiso,
                FechaCierre = necesidad.FechaCierre,
                EstadoNecesidadId = necesidad.EstadoNecesidadId,
                EstadoNecesidadNombre = necesidad.EstadoNecesidad?.Nombre,
                NombreCentro = necesidad.Centro?.Nombre,
                PersonaAsignada = necesidad.GetPersonaAsignada(),
                PersonaAsignadaId = necesidad.PersonaAsignadaId,
                PersonaAsignadaNroEmpleado = necesidad.PersonaAsignadaNroEmpleado,
                Modulo = necesidad.Modulo,
                NombreModulo = GetNombreModulo(necesidad.Modulo),
                candidaturaId = necesidad.CandidaturaId,
                ReferenciaExterna = necesidad.ReferenciaExterna,
                AsignadaCorrectamente = necesidad.AsignadaCorrectamente,
                GrupoNecesidad = necesidad.GrupoNecesidadId,
                GrupoNecesidadName = necesidad.GrupoNecesidadId != null ? necesidad.GrupoNecesidad.Nombre : string.Empty,
                Activo = necesidad.IsActivo
            };

            if ((necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada 
                || necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                && necesidad.TipoContratacionId == (int)TipoContratacionEnum.Contratación)
            {
                createEditNecesidadViewModel.PersonaAsignadaNroEmpleado = null;
            }

            if (necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
            {
                createEditNecesidadViewModel.candidaturaId = null;
            }

            return createEditNecesidadViewModel;
        }

        public static void UpdateNecesidad(this Necesidad necesidad, CreateEditNecesidadViewModel createEditNecesidadViewModel, Proyecto proyecto)
        {
            if (createEditNecesidadViewModel.NecesidadId != null)
            {
                necesidad.NecesidadId = (int)createEditNecesidadViewModel.NecesidadId;

                necesidad.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                necesidad.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                necesidad.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                necesidad.Created = ModifiableEntityHelper.GetCurrentDate();
            }
            necesidad.Nombre = createEditNecesidadViewModel.Nombre;
            necesidad.OficinaId = createEditNecesidadViewModel.OficinaId;
            necesidad.CentroId = createEditNecesidadViewModel.CentroId;
            necesidad.SectorId = createEditNecesidadViewModel.SectorId;
            necesidad.ProyectoId = createEditNecesidadViewModel.ProyectoId;
            necesidad.TipoServicioId = createEditNecesidadViewModel.TipoServicioId;
            necesidad.TipoPerfilId = createEditNecesidadViewModel.TipoPerfilId;
            necesidad.TipoTecnologiaId = createEditNecesidadViewModel.TipoTecnologiaId;
            necesidad.TipoContratacionId = createEditNecesidadViewModel.TipoContratacionId;
            necesidad.DisponibilidadViaje = createEditNecesidadViewModel.DisponibilidadViajes;
            necesidad.CambioResidencia = createEditNecesidadViewModel.DisponibilidadReubicacion;
            necesidad.NecesidadIdioma = createEditNecesidadViewModel.NecesidadIdioma;
            necesidad.TipoPrevisionId = createEditNecesidadViewModel.TipoPrevisionId;
            necesidad.MesesAsignacionId = createEditNecesidadViewModel.MesesAsignacionId;
            necesidad.Observaciones = createEditNecesidadViewModel.DetalleTecnologia ?? necesidad.Observaciones;
            necesidad.EstadoNecesidadId = createEditNecesidadViewModel.EstadoNecesidadId;
            necesidad.FechaSolicitud = (DateTime)createEditNecesidadViewModel.FechaSolicitud;
            necesidad.FechaCompromiso = createEditNecesidadViewModel.FechaCompromiso;
            necesidad.FechaCierre = createEditNecesidadViewModel.FechaCierre;
            necesidad.IsActivo = true;
            necesidad.ReferenciaExterna = createEditNecesidadViewModel.ReferenciaExterna;
            necesidad.AsignadaCorrectamente = createEditNecesidadViewModel.AsignadaCorrectamente;
            necesidad.EstadoNecesidadId = createEditNecesidadViewModel.EstadoNecesidadId;
            if ((createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada
                || createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                && createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
            {
                necesidad.PersonaAsignada = createEditNecesidadViewModel.PersonaAsignada;
                necesidad.PersonaAsignadaId = createEditNecesidadViewModel.PersonaAsignadaId;
                necesidad.PersonaAsignadaNroEmpleado = createEditNecesidadViewModel.PersonaAsignadaNroEmpleado;
            }
            else if ((createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada
                || createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
                 && createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.Contratación)
            {
                necesidad.PersonaAsignada = createEditNecesidadViewModel.PersonaAsignada;
                necesidad.PersonaAsignadaId = createEditNecesidadViewModel.PersonaAsignadaId;
                necesidad.PersonaAsignadaNroEmpleado = null;
                necesidad.CandidaturaId = createEditNecesidadViewModel.candidaturaId;
            }
            else if(createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta
                && createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.Contratación
                && createEditNecesidadViewModel.PersonaAsignadaId != null)
            {
                necesidad.PersonaAsignadaId = null;
                necesidad.CandidaturaId = null;
                necesidad.PersonaAsignada = null;
            }
            else if(createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta
                && createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno
                && createEditNecesidadViewModel.PersonaAsignadaId != null)
            {
                necesidad.PersonaAsignadaId = null;
                necesidad.PersonaAsignada = null;
                necesidad.PersonaAsignadaNroEmpleado = null;
            }
            if (createEditNecesidadViewModel.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
            {
                necesidad.CandidaturaId = null;
            }
            necesidad.Modulo = createEditNecesidadViewModel.Modulo;

            if (createEditNecesidadViewModel.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada && createEditNecesidadViewModel.AsignadaCorrectamente == null)
            {
                necesidad.AsignadaCorrectamente = false;
            }
            if (createEditNecesidadViewModel.GrupoNecesidad != null && createEditNecesidadViewModel.GrupoNecesidad != 0)
            {
                necesidad.GrupoNecesidadId = createEditNecesidadViewModel.GrupoNecesidad;
            }

            if (proyecto != null)
            {
                necesidad.CuentaProyecto = proyecto.CuentaCargo;
                necesidad.PersonaProyecto = proyecto.Persona;
            }
        }

        public static IEnumerable<NecesidadRowViewModel> ConvertToNecesidadRowViewModel(this IEnumerable<Necesidad> NecesidadList)
        {
            var NecesidadRowViewModelList = new List<NecesidadRowViewModel>();

            if (NecesidadList == null) return NecesidadRowViewModelList;

            NecesidadRowViewModelList = NecesidadList.Select(x => x.ConvertToNecesidadRowViewModel()).ToList();

            return NecesidadRowViewModelList;
        }

        public static IEnumerable<NecesidadRowExportToExcelViewModel> ConvertToNecesidadRowExportToExcelViewModel(this IEnumerable<Necesidad> NecesidadList)
        {
            var NecesidadRowExportToExcelViewModelList = new List<NecesidadRowExportToExcelViewModel>();

            if (NecesidadList == null) return NecesidadRowExportToExcelViewModelList;

            NecesidadRowExportToExcelViewModelList = NecesidadList.Select(x => x.ConvertToNecesidadRowExportToExcelViewModel()).ToList();

            return NecesidadRowExportToExcelViewModelList;
        }

        public static IEnumerable<NecesidadStaffingRowExportToExcelViewModel> ConvertToNecesidadStaffingRowExportToExcelViewModel(this IEnumerable<Necesidad> NecesidadList)
        {
            var NecesidadStaffingRowExportToExcelViewModelList = new List<NecesidadStaffingRowExportToExcelViewModel>();

            if (NecesidadList == null) return NecesidadStaffingRowExportToExcelViewModelList;

            NecesidadStaffingRowExportToExcelViewModelList = NecesidadList.Select(x => x.ConvertToNecesidadStaffingRowExportToExcelViewModel()).ToList();

            return NecesidadStaffingRowExportToExcelViewModelList;
        }

        public static CreateEditGrupoNecesidadViewModel ConvertToCreateEditGrupoNecesidadViewModel(GrupoNecesidad grupo, IEnumerable<Necesidad> necesidades)
        {
            var grupoVM = new CreateEditGrupoNecesidadViewModel();
            var necesidadComun = necesidades.FirstOrDefault();
            grupoVM.ListaNecesidades = necesidades.Select(x => x.ConvertToCreateEditNecesidadViewModel()).ToList();
            grupoVM.NombreGrupo = grupo.Nombre;
            grupoVM.DescripcionGrupo = grupo.Descripcion;
            grupoVM.GrupoNecesidadId = grupo.GrupoNecesidadId;
            grupoVM.EstadoGrupo = grupo.GrupoCerrado;
            grupoVM.CentroId = necesidadComun.CentroId;
            grupoVM.ClienteId = necesidadComun.Proyecto.ClienteId;
            grupoVM.DetalleTecnologia = necesidadComun.Observaciones;
            grupoVM.DisponibilidadReubicacion = (necesidadComun.CambioResidencia == true);
            grupoVM.DisponibilidadViajes = (necesidadComun.DisponibilidadViaje == true);
            grupoVM.FechaSolicitud = necesidadComun.FechaSolicitud;
            grupoVM.MesesAsignacionId = necesidadComun.MesesAsignacionId;
            grupoVM.NecesidadIdioma = (necesidadComun.NecesidadIdioma == true);
            grupoVM.OficinaId = necesidadComun.OficinaId;
            grupoVM.ProyectoId = necesidadComun.ProyectoId;
            grupoVM.SectorId = necesidadComun.SectorId;
            grupoVM.TipoServicioId = (necesidadComun.Proyecto.ServicioId.HasValue) ? necesidadComun.Proyecto.ServicioId.Value : 0;
            grupoVM.Activo = grupo.IsActivo;
            return grupoVM;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = name;

            switch (name)
            {
                case "Cliente":
                    attributeName = "Proyecto.ClienteId";
                    break;
                case "Proyecto":
                    attributeName = "ProyectoId";
                    break;
                case "Tecnologia":
                    attributeName = "TipoTecnologiaId";
                    break;
                case "Estado":
                    attributeName = "EstadoNecesidadId";
                    break;
                case "Perfil":
                    attributeName = "TipoPerfilId";
                    break;
                case "FechaCompromiso":
                    attributeName = "FechaCompromiso";
                    break;
                case "Prevision":
                    attributeName = "TipoPrevisionId";
                    break;
                case "PersonaAsignada":
                    attributeName = "PersonaAsignada";
                    break;
                case "Modulo":
                    attributeName = "Modulo";
                    break;
                case "Centro":
                    attributeName = "Centro.Nombre";
                    break;
                case "FechaCreacion":
                    attributeName = "Created";
                    break;
                case "FehaModificacion":
                    attributeName = "Modified";
                    break;
                case "FechaSolicitud":
                    attributeName = "FechaSolicitud";
                    break;
                case "FechaCierre":
                    attributeName = "FechaCierre";
                    break;
            }
            return attributeName;
        }

        public static string GetPropertiePathCandidatura(string name)
        {
            string attributeName = name;

            switch (name)
            {
                case "PersonaId":
                    attributeName = "CandidaturaId";
                    break;
                case "NombreCompleto":
                    attributeName = "Candidato.Nombre";
                    break;
            }
            return attributeName;
        }

        public static string GetPropertiePathPersonaLibre(string name)
        {
            string attributeName = name;

            switch (name)
            {
                case "PersonaId":
                    attributeName = "PersonaLibreId";
                    break;
                case "NombreCompleto":
                    attributeName = "Nombre";
                    break;
            }
            return attributeName;
        }

        #endregion

        private static string GetPersonaAsignada(this Necesidad necesidad)
        {
            var personaAsignada = string.Empty;
            //Necesidad Cerrada
            if (necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada)
            {
                //Contratacion == Cambio Interno
                if (necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno)
                {
                    personaAsignada = necesidad.PersonaAsignada;
                }
                else if (necesidad.CartasOferta.Any())
                {
                    var candidato = necesidad.CartasOferta.FirstOrDefault().Candidatura.Candidato;
                    personaAsignada = string.Format("{0} {1}", candidato.Nombre, candidato.Apellidos);
                }
            }
            else if(necesidad.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada && (necesidad.TipoContratacionId == (int)TipoContratacionEnum.CambioInterno ||
                    necesidad.TipoContratacionId == (int)TipoContratacionEnum.Contratación))
            {
                    personaAsignada = necesidad.PersonaAsignada;
            }

            return personaAsignada;
        }

        private static string GetNombreModulo(string modulo)
        {
            string nombreModulo = "";

            var moduloId = Convert.ToInt32(modulo);

            switch (moduloId)
            {
                case (int)TipoModuloEnum.ABAP:
                    nombreModulo = "ABAP";
                    break;
                case (int)TipoModuloEnum.BI:
                    nombreModulo = "BI";
                    break;
                case (int)TipoModuloEnum.BW:
                    nombreModulo = "BW";
                    break;
                case (int)TipoModuloEnum.FI:
                    nombreModulo = "FI";
                    break;
                case (int)TipoModuloEnum.HR:
                    nombreModulo = "HR";
                    break;
                case (int)TipoModuloEnum.LO:
                    nombreModulo = "LO";
                    break;
                case (int)TipoModuloEnum.SFSS:
                    nombreModulo = "SFSS";
                    break;
                default:
                    nombreModulo = "";
                    break;
            }

            return nombreModulo;
        }
    }
}
