using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Helpers;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Recruiting.Application.Candidatos.Mappers
{
    public static class CandidatoMapper
    {
        #region Mapper

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

        public static IEnumerable<CandidatoRowViewModel> ConvertToCandidatoRowViewModel(this IDictionary<Candidato, GetDatosByCandidatoIdResponse> relacionCandidatoCandituras, List<int> candidatosNoPuedenCandidatura)
        {
            var candidatoRowViewModelList = new List<CandidatoRowViewModel>();

            var response = (relacionCandidatoCandituras == null)
                ? candidatoRowViewModelList
                : relacionCandidatoCandituras.Select(x => x.Key.ConvertToCandidatoRowViewModel(x.Value.NumCandidaturas, x.Value.NivelIngles, candidatosNoPuedenCandidatura)).ToList();

            return response;

        }

        public static IEnumerable<CandidatoRowViewModel> ConvertToCandidatoRowViewModel(this IEnumerable<Candidato> candidatosFiltrados)
        {
            var candidatoRowViewModelList = new List<CandidatoRowViewModel>();

            var response = (candidatosFiltrados == null)
                ? candidatoRowViewModelList
                : candidatosFiltrados.Select(x => x.ConvertToCandidatoRowViewModel(null, "",null)).ToList();

            return response;

        }

        public static IEnumerable<CandidatoRowExportToExcelViewModel> ConvertToCandidatoRowExportToExcelViewModel(this IDictionary<Candidato, GetDatosByCandidatoIdResponse> relacionCandidatoCandituras)
        {
            var candidatoRowExportToExcelViewModelList = new List<CandidatoRowExportToExcelViewModel>();

            var response = (relacionCandidatoCandituras == null)
                ? candidatoRowExportToExcelViewModelList
                : relacionCandidatoCandituras.Select(x => x.Key.ConvertToCandidatoRowExportToExcelViewModel(x.Value.NumCandidaturas, x.Value.NivelIngles)).ToList();

            return response;

        }

        public static void UpdateCandidato(this Candidato candidato, CandidaturaDatosBasicosViewModel viewModel)
        {

            if (viewModel.DatosBasicos.CandidatoId != 0)
            {
                candidato.CandidatoId = (int)viewModel.DatosBasicos.CandidatoId;

                candidato.Modified = ModifiableEntityHelper.GetCurrentDate();
                candidato.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            }
            else
            {
                candidato.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                candidato.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            candidato.UpdateCandidatoIdioma2(viewModel.DatosBasicos.IdiomaCandidatoViewModel);
            candidato.UpdateCandidatoExperiencia2(viewModel.DatosBasicos.ExpCandidatoViewModel);

        }

        public static void UpdateCandidato(this Candidato candidato, CreateEditCandidatoViewModel viewModel)
        {

            candidato.Apellidos = viewModel.Apellidos.Trim();
            candidato.CambioResidencia = viewModel.CambioResidencia;

            if (viewModel.CandidatoId != null)
            {
                candidato.CandidatoId = (int)viewModel.CandidatoId;

                candidato.Modified = ModifiableEntityHelper.GetCurrentDate();
                candidato.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
            }
            else
            {
                candidato.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                candidato.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            candidato.NumeroIdentificacion = viewModel.NumeroIdentificacion;
            candidato.DetalleTitulacion = viewModel.DetalleTitulacion;
            candidato.DisponibilidadViaje = viewModel.DisponibilidadViaje;
            candidato.EstadoCandidatoId = 20;
            candidato.FechaNacimiento = viewModel.FechaNacimiento;
            candidato.IsActivo = true;
            candidato.Nombre = viewModel.Nombres.Trim();
            candidato.TipoIdentificacionId = viewModel.TipoIdentificacionId;
            candidato.TitulacionId = viewModel.TitulacionId;
            candidato.Direccion = viewModel.Direccion;
            candidato.AnioRegresado = viewModel.AnioRegresado;
            candidato.CandidatoCentroEducativoId = viewModel.CandidatoCentroEducativoId;
            candidato.UpdateCandidatoIdioma(viewModel.IdiomaCandidatoViewModel);
            candidato.UpdateCandidatoExperiencia(viewModel.ExpCandidatoViewModel);
            candidato.UpdateCandidatoContacto(viewModel.ContactCandidatoViewModel);

        }

        public static CreateEditCandidatoViewModel ConvertToCreateEditCandidatoViewModel(this Candidato candidato)
        {
            var candidatoIdioma = candidato.CandidatoIdiomas.ConvertToCreateEditRowIdiomaCandidatoViewModel().ToList();
            var candidatoExperiencia = candidato.CandidatoExperiencias.ConvertToCreateEditRowExpCandidatoViewModel().ToList();
            var candidatoContacto = candidato.CandidatoContactos.ConvertToCreateEditRowContactoCandidatoViewModel().ToList();

            return new CreateEditCandidatoViewModel()
            {
                Apellidos = candidato.Apellidos,
                CambioResidencia = candidato.CambioResidencia,
                CandidatoId = candidato.CandidatoId,
                DetalleTitulacion = candidato.DetalleTitulacion,
                DisponibilidadViaje = candidato.DisponibilidadViaje,
                EstadoCandidatoId = candidato.EstadoCandidatoId,
                FechaNacimiento = candidato.FechaNacimiento,
                Nombres = candidato.Nombre,
                NumeroIdentificacion = candidato.NumeroIdentificacion,
                TipoIdentificacionId = candidato.TipoIdentificacionId,
                TipoIdentificacion = candidato.TipoIdentificacion != null ? candidato.TipoIdentificacion.Nombre : string.Empty,
                TitulacionId = candidato.TitulacionId,
                Titulacion = candidato.Titulacion != null ? candidato.Titulacion.Nombre : string.Empty,
                IdiomaCandidatoViewModel = candidatoIdioma,
                ExpCandidatoViewModel = candidatoExperiencia,
                ContactCandidatoViewModel = candidatoContacto,
                Activo = candidato.IsActivo,
                Direccion = candidato.Direccion,
                AnioRegresado = candidato.AnioRegresado,
                CandidatoCentroEducativoId = candidato.CandidatoCentroEducativoId,
                NombreCentroEducativo = candidato.CandidatoCentroEducativoId == null ? null : candidato.CandidatoCentroEducativo.Centro
            };
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Referencia":
                    attributeName = "CandidatoId";
                    break;
                case "Apellidos":
                    attributeName = "Apellidos";
                    break;
                case "Titulacion":
                    attributeName = "TiTulacionId";
                    break;
                case "Identificacion":
                    attributeName = "TipoIdentificacionId";
                    break;
                case "FechaNacimiento":
                    attributeName = "FechaNacimiento";
                    break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
                case "NivelIdioma":
                    attributeName = "CandidatoIdiomas.NivelIdiomaId.Maestro";
                    break;
            }

            return attributeName;
        }

        public static string GetPropertiePathCandidaturas(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Estado":
                    attributeName = "EstadoCandidaturaId";
                    break;

                case "Oferta":
                    attributeName = "Oferta.Nombre";
                    break;

                case "Etapa":
                    attributeName = "EtapaCandidaturaId";
                    break;
                case "Perfil":
                    attributeName = "CategoriaId";
                    break;
                case "Entrevistador":
                    attributeName = "Entrevista.EntrevistadorId";
                    break;
                case "Candidato":
                    attributeName = "CandidatoId";
                    break;
                case "CandidaturaId":
                    attributeName = "CandidaturaId";
                    break;
                case "Agendada":
                    attributeName = "Entrevistas.FechaEntrevista";
                    break;
                case "TipoTecnologia":
                    attributeName = "TipoTecnologiaId";
                    break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
                case "Modulo":
                    attributeName = "TipoModulo.Nombre";
                    break;
                case "OrigenCvId":
                    attributeName = "OrigenCvId";
                    break;
                case "PersonaCreacion":
                    attributeName = "Usuario.Nombre";
                    break;
            }
            return attributeName;
        }

        public static string GetPropertiePathBecarios(string name)
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
                case "CentroProcedencia":
                    attributeName = "BecarioCentroProcedencia.Centro";
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
                case "PersonaCreacion":
                    attributeName = "Usuario.Nombre";
                    break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;


            }
            return attributeName;
        }

        public static IEnumerable<CandidaturaModalRowViewModel> ConvertToCandidaturaModalRowViewModel(this IEnumerable<Candidatura> candidaturaList)
        {
            var candidaturaModalRowViewModelList = new List<CandidaturaModalRowViewModel>();

            if (candidaturaList == null) return candidaturaModalRowViewModelList;

            candidaturaModalRowViewModelList = candidaturaList.Select(x => x.ConvertToCandidaturaModalRowViewModel()).ToList();

            return candidaturaModalRowViewModelList;
        }

        public static IEnumerable<BecarioModalRowViewModel> ConvertToBecarioModalRowViewModel(this IEnumerable<Becario> becarioList)
        {
            var becarioModalRowViewModelList = new List<BecarioModalRowViewModel>();

            if (becarioList == null) return becarioModalRowViewModelList;

            becarioModalRowViewModelList = becarioList.Select(x => x.ConvertToBecarioModalRowViewModel()).ToList();

            return becarioModalRowViewModelList;
        }



        #region Private Methods

        private static CandidatoRowViewModel ConvertToCandidatoRowViewModel(this Candidato candidato, int? numCandidaturasAsociadas, string nivelIdioma, List<int> candidatosNoPuedenCandidatura)
        {
            var vieModel = new CandidatoRowViewModel()
            {
                Apellidos = candidato.Apellidos,
                CandidatoId = candidato.CandidatoId,
                FechaNacimiento = candidato.FechaNacimiento,
                Nombres = candidato.Nombre,
                NumeroIdentificacion = candidato.NumeroIdentificacion,
                NumCandidaturasAsociadas = numCandidaturasAsociadas,
                NivelIdioma = nivelIdioma,
                Titulacion = candidato.Titulacion.Nombre,
                CVAvailable = false,
                CandidaturaAvailable = true,
                ExistenCandidaturas = false,
                Centro = candidato.Usuario.CentroId != null ? candidato.Usuario.Centro.Nombre : string.Empty
            };

            vieModel.CandidaturaAvailable = (candidatosNoPuedenCandidatura != null) && !candidatosNoPuedenCandidatura.Contains(candidato.CandidatoId);

            return vieModel;
        }


        private static CandidatoRowExportToExcelViewModel ConvertToCandidatoRowExportToExcelViewModel(this Candidato candidato, int numCandidaturasAsociadas, string nivelIngles)
        {
            var vieModel = new CandidatoRowExportToExcelViewModel()
            {
                Apellidos = candidato.Apellidos,
                FechaNacimiento = candidato.FechaNacimiento != null ? candidato.FechaNacimiento.Value.ToShortDateString() : string.Empty,
                Nombres = candidato.Nombre,
                NumeroIdentificacion = candidato.NumeroIdentificacion,
                numCandidaturasAsociadas = numCandidaturasAsociadas,
                Titulacion = candidato.Titulacion.Nombre,
                CentroEducativo = candidato.CandidatoCentroEducativoId != null ? candidato.CandidatoCentroEducativo.Centro : string.Empty,
                AnioRegresado = candidato.AnioRegresado,
                Centro = candidato.Usuario.CentroId != null ? candidato.Usuario.Centro.Nombre : string.Empty,
                NivelIngles = nivelIngles
            };

            return vieModel;
        }


        private static void UpdateCandidatoIdioma(this Candidato candidato, List<Recruiting.Application.Candidatos.ViewModels.CreateEditRowIdiomaCandidatoViewModel> listRowCreateEditIdiomaCandidatoViewModel)
        {
            //actualizar o añadir el resto
            foreach (var idiomaViewModel in listRowCreateEditIdiomaCandidatoViewModel)
            {
                if (candidato.CandidatoIdiomas != null)
                {
                    if (!candidato.CandidatoIdiomas.Any(x => x.CandidatoIdiomasId == idiomaViewModel.CandidatoIdiomasId) ||
                        idiomaViewModel.CandidatoId == 0)
                    {
                        //añadir
                        candidato.CandidatoIdiomas.Add(new CandidatoIdioma()
                        {
                            CandidatoId = candidato.CandidatoId,
                            IdiomaId = idiomaViewModel.IdiomaId,
                            NivelIdiomaId = idiomaViewModel.NivelIdiomaId,
                            IsActivo = true
                        });
                    }
                    else
                    {
                        //actualizar
                        var candidatoIdioma = candidato.CandidatoIdiomas.Single(x => x.CandidatoIdiomasId == idiomaViewModel.CandidatoIdiomasId);
                        candidatoIdioma.CandidatoId = idiomaViewModel.CandidatoId;
                        candidatoIdioma.CandidatoIdiomasId = (int)idiomaViewModel.CandidatoIdiomasId;
                        candidatoIdioma.IdiomaId = idiomaViewModel.IdiomaId;
                        candidatoIdioma.NivelIdiomaId = idiomaViewModel.NivelIdiomaId;
                    }
                }
                else
                {
                    candidato.CandidatoIdiomas = new List<CandidatoIdioma>
                    {
                        //añadir
                        new CandidatoIdioma()
                        {
                            CandidatoId = idiomaViewModel.CandidatoId,
                            IdiomaId = idiomaViewModel.IdiomaId,
                            NivelIdiomaId = idiomaViewModel.NivelIdiomaId,
                            IsActivo = true
                        }
                    };
                }
            }
        }

        private static void UpdateCandidatoIdioma2(this Candidato candidato, List<Recruiting.Application.Candidaturas.ViewModel.CreateEditRowIdiomaCandidaturaViewModel> listRowCreateEditIdiomaCandidatoViewModel)
        {
            //actualizar o añadir el resto
            foreach (var idiomaViewModel in listRowCreateEditIdiomaCandidatoViewModel)
            {
                if (candidato.CandidatoIdiomas != null)
                {
                    if (!candidato.CandidatoIdiomas.Any(x => x.CandidatoIdiomasId == idiomaViewModel.CandidatoIdiomasId) ||
                        idiomaViewModel.CandidatoId == 0)
                    {
                        //añadir
                        candidato.CandidatoIdiomas.Add(new CandidatoIdioma()
                        {
                            CandidatoId = candidato.CandidatoId,
                            IdiomaId = idiomaViewModel.IdiomaId,
                            NivelIdiomaId = idiomaViewModel.NivelIdiomaId,
                            IsActivo = true
                        });
                    }
                    else
                    {
                        //actualizar
                        var candidatoIdioma = candidato.CandidatoIdiomas.Single(x => x.CandidatoIdiomasId == idiomaViewModel.CandidatoIdiomasId);
                        candidatoIdioma.CandidatoId = idiomaViewModel.CandidatoId;
                        candidatoIdioma.CandidatoIdiomasId = (int)idiomaViewModel.CandidatoIdiomasId;
                        candidatoIdioma.IdiomaId = idiomaViewModel.IdiomaId;
                        candidatoIdioma.NivelIdiomaId = idiomaViewModel.NivelIdiomaId;
                    }
                }
                else
                {
                    candidato.CandidatoIdiomas = new List<CandidatoIdioma>
                    {
                        //añadir
                        new CandidatoIdioma()
                        {
                            CandidatoId = idiomaViewModel.CandidatoId,
                            IdiomaId = idiomaViewModel.IdiomaId,
                            NivelIdiomaId = idiomaViewModel.NivelIdiomaId,
                            IsActivo = true
                        }
                    };
                }
            }
        }

        private static void UpdateCandidatoExperiencia(this Candidato candidato, List<Recruiting.Application.Candidatos.ViewModels.CreateEditRowExperienciaCandidatoViewModel> listRowCreateEditExperienciaCandidatoViewModel)
        {
            foreach (var experienciaViewModel in listRowCreateEditExperienciaCandidatoViewModel)
            {
                if (candidato.CandidatoExperiencias != null)
                {
                    if (!candidato.CandidatoExperiencias.Any(x => x.CandidatoExperienciaId == experienciaViewModel.CandidatoExperienciaId) ||
                        experienciaViewModel.CandidatoExperienciaId == 0)
                    {
                        candidato.CandidatoExperiencias.Add(new CandidatoExperiencia()
                            {
                                CandidatoId = candidato.CandidatoId,
                                TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId,
                                NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId,
                                Experiencia = experienciaViewModel.Experiencia,
                                IsActivo = true
                            });
                    }
                    else
                    {
                        var candidatoExperiencia = candidato.CandidatoExperiencias.Single(x => x.CandidatoExperienciaId == experienciaViewModel.CandidatoExperienciaId);
                        candidatoExperiencia.CandidatoId = experienciaViewModel.CandidatoId;
                        candidatoExperiencia.CandidatoExperienciaId = (int)experienciaViewModel.CandidatoExperienciaId;
                        candidatoExperiencia.TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId;
                        candidatoExperiencia.NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId;
                        candidatoExperiencia.Experiencia = experienciaViewModel.Experiencia;
                    }
                }
                else
                {
                    candidato.CandidatoExperiencias = new List<CandidatoExperiencia>
                    {
                        new CandidatoExperiencia()
                        {
                            CandidatoId = experienciaViewModel.CandidatoId,
                            TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId,
                            NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId,
                            Experiencia = experienciaViewModel.Experiencia,
                            IsActivo = true
                        }
                    };
                }
            }
        }

        private static void UpdateCandidatoExperiencia2(this Candidato candidato, List<Recruiting.Application.Candidaturas.ViewModels.CreateEditRowExperienciaCandidatoViewModel> listRowCreateEditExperienciaCandidatoViewModel)
        {
            foreach (var experienciaViewModel in listRowCreateEditExperienciaCandidatoViewModel)
            {
                if (candidato.CandidatoExperiencias != null)
                {
                    if (!candidato.CandidatoExperiencias.Any(x => x.CandidatoExperienciaId == experienciaViewModel.CandidatoExperienciaId) ||
                        experienciaViewModel.CandidatoExperienciaId == 0)
                    {
                        candidato.CandidatoExperiencias.Add(new CandidatoExperiencia()
                        {
                            CandidatoId = candidato.CandidatoId,
                            TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId,
                            NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId,
                            Experiencia = experienciaViewModel.Experiencia,
                            IsActivo = true
                        });
                    }
                    else
                    {
                        var candidatoExperiencia = candidato.CandidatoExperiencias.Single(x => x.CandidatoExperienciaId == experienciaViewModel.CandidatoExperienciaId);
                        candidatoExperiencia.CandidatoId = experienciaViewModel.CandidatoId;
                        candidatoExperiencia.CandidatoExperienciaId = (int)experienciaViewModel.CandidatoExperienciaId;
                        candidatoExperiencia.TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId;
                        candidatoExperiencia.NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId;
                        candidatoExperiencia.Experiencia = experienciaViewModel.Experiencia;
                    }
                }
                else
                {
                    candidato.CandidatoExperiencias = new List<CandidatoExperiencia>
                    {
                        new CandidatoExperiencia()
                        {
                            CandidatoId = experienciaViewModel.CandidatoId,
                            TipoTecnologiaId = experienciaViewModel.TipoTecnologiaId,
                            NivelTecnologiaId = experienciaViewModel.NivelTecnologiaId,
                            Experiencia = experienciaViewModel.Experiencia,
                            IsActivo = true
                        }
                    };
                }
            }
        }


        private static void UpdateCandidatoContacto(this Candidato candidato, List<CreateEditRowContactoCandidatoViewModel> listRowContactoCandidatoViewModel)
        {
            foreach (var contactoViewModel in listRowContactoCandidatoViewModel)
            {
                if (candidato.CandidatoContactos != null)
                {
                    if (!candidato.CandidatoContactos.Any(x => x.CandidatoContactoId == contactoViewModel.CandidatoContactoId) ||
                        contactoViewModel.CandidatoContactoId == 0)
                    {
                        candidato.CandidatoContactos.Add(new CandidatoContacto()
                            {
                                CandidatoId = candidato.CandidatoId,
                                TipoMedioContactoId = contactoViewModel.TipoMedioContactoId,
                                Contacto = contactoViewModel.ValorContacto,
                                IsActivo = true
                            });
                    }
                    else
                    {
                        var candidatoContacto = candidato.CandidatoContactos.Single(x => x.CandidatoContactoId == contactoViewModel.CandidatoContactoId);
                        candidatoContacto.CandidatoId = contactoViewModel.CandidatoId;
                        candidatoContacto.CandidatoContactoId = (int)contactoViewModel.CandidatoContactoId;
                        candidatoContacto.TipoMedioContactoId = contactoViewModel.TipoMedioContactoId;
                        candidatoContacto.Contacto = contactoViewModel.ValorContacto;
                    }
                }
                else
                {
                    candidato.CandidatoContactos = new List<CandidatoContacto>
                    {
                        new CandidatoContacto()
                        {
                            CandidatoId = contactoViewModel.CandidatoId,
                            TipoMedioContactoId = contactoViewModel.TipoMedioContactoId,
                            Contacto = contactoViewModel.ValorContacto,
                            IsActivo = true
                        }
                    };
                }
            }
        }

        private static CandidaturaModalRowViewModel ConvertToCandidaturaModalRowViewModel(this Candidatura candidatura)
        {
            var entrevistadorNombre = string.Empty;
            int? entrevistadorId = null;
            var agendada = new DateTime?();
            var ofertaNombre = String.Empty;

            var tupla = GetEntrevistadorYAgendada(candidatura, candidatura.EtapaCandidatura.TipoEtapaCandidaturaId);
            if (tupla != null)
            {
                if (tupla.Item1 != null)
                {
                    entrevistadorNombre = tupla.Item1.Nombre;
                    entrevistadorId = tupla.Item1.UsuarioId;
                }
                agendada = (tupla.Item2.HasValue) ? (tupla.Item2) : null;
            }

            var candidaturaRowViewModel = new CandidaturaModalRowViewModel()
            {
                CandidaturaId = candidatura.CandidaturaId,
                Estado = candidatura.EstadoCandidatura.EstadoCandidatura,
                Etapa = candidatura.EtapaCandidatura.EtapaCandidatura,
                Candidato = candidatura.Candidato.Nombre + ' ' + candidatura.Candidato.Apellidos,
                Oferta = ofertaNombre,
                OrigenCvId = candidatura.OrigenCvId,
                FuenteReclutamientoId = candidatura.FuenteReclutamientoId,
                Entrevistador = entrevistadorNombre,
                EntrevistadorId = entrevistadorId,
                Agendada = (agendada.HasValue) ? agendada.Value : new DateTime(),
                CandidatoId = candidatura.CandidatoId,
                EstadoId = candidatura.EstadoCandidaturaId,
                EtapaId = candidatura.EtapaCandidaturaId,
                TipoTecnologiaId = candidatura.TipoTecnologiaId,
                Modulo = (candidatura.ModuloId.HasValue) ? candidatura.TipoModulo.Nombre : "",
                PersonaCreacion = candidatura.Usuario.Nombre,
                CentroId = candidatura.Usuario.CentroId,
                Centro = candidatura.Usuario.CentroId != null ? candidatura.Usuario.Centro.Nombre : string.Empty,
                FiltradorId = candidatura.FiltradorId,
                SubEntrevistadoresString = ""
                
            };

            if (candidatura.Categoria != null)
            {
                candidaturaRowViewModel.Perfil = candidatura.Categoria.Nombre;
            }

            candidaturaRowViewModel.TipoTecnologia = candidatura.TipoTecnologia == null ? null : (candidatura.TipoTecnologia.Nombre ?? null);
            if (candidaturaRowViewModel.OrigenCvId != null)
            {
                candidaturaRowViewModel.OrigenCv = candidatura.OrigenCv.Nombre;
            }
            else
            {
                candidaturaRowViewModel.OrigenCv = "";
            }


            return candidaturaRowViewModel;
        }

        private static BecarioModalRowViewModel ConvertToBecarioModalRowViewModel(this Becario becario)
        {         
         

            var becarioRowViewModel = new BecarioModalRowViewModel()
            {
                BecarioId = becario.BecarioId,
                BecarioNombre = becario.Candidato.Nombre + " " + becario.Candidato.Apellidos,
                CandidatoId = becario.CandidatoId,
                TipoBecario = becario.TipoBecario.Nombre,
                CentroProcedencia = becario.BecarioCentroProcedencia != null ? becario.BecarioCentroProcedencia.Centro : string.Empty,                
                Cliente = becario.ClienteId != null ? becario.Cliente.Nombre : string.Empty,
                Proyecto = becario.ProyectoId != null ? becario.Proyecto.Nombre : string.Empty,
                FechaInicio = becario.FechaBecaInicio.ToString(),
                FechaFin = becario.FechaBecaFin.ToString(),
                FechaFinReal = becario.FechaBecaFinReal.ToString(),
                EstadoBecarioId = becario.TipoEstadoBecarioId,
                PersonaCreacion= becario.Usuario.Nombre,
                EstadoBecario = becario.TipoEstadoBecario.EstadoBecario,
                CentroId = becario.Usuario.CentroId,
                Centro = becario.Usuario.CentroId != null ? becario.Usuario.Centro.Nombre : string.Empty,
               

            };

            return becarioRowViewModel;
        }

        private static Tuple<Usuario, DateTime?> GetEntrevistadorYAgendada(Candidatura candidatura, int etapa)
        {
            Tuple<Usuario, DateTime?> result = null;

            switch (etapa)
            {
                case (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista:
                case (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista:
                case (int)TipoEtapaCandidaturaEnum.AgendarEntrevistas:
                case (int)TipoEtapaCandidaturaEnum.AgendarSegundaEntrevista:
                case (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta:

                    if ((candidatura.Entrevistas != null) && candidatura.Entrevistas.Any())
                    {
                        var entrevista = candidatura.Entrevistas.OrderBy(x => x.EntrevistaId).Last();
                        result = new Tuple<Usuario, DateTime?>(entrevista.Entrevistador, entrevista.FechaEntrevista);
                    }

                    break;

                case (int)TipoEtapaCandidaturaEnum.EntregaCartaOferta:
                case (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta:
                case (int)TipoEtapaCandidaturaEnum.Fin:

                    if ((candidatura.CartaOfertas != null) && candidatura.CartaOfertas.Any())
                    {
                        var cataOferta = candidatura.CartaOfertas.OrderBy(x => x.CartaOfertaId).Last();
                        result = new Tuple<Usuario, DateTime?>(cataOferta.Entrevistador, cataOferta.FechaCartaOferta);
                    }

                    break;
                case (int)TipoEtapaCandidaturaEnum.FiltradoTecnico:
                    if (candidatura.Filtrador != null)
                    {
                        result = new Tuple<Usuario, DateTime?>(candidatura.Filtrador, null);
                    }
                    break;
            }

            return result;
        }
     



        #endregion

        #endregion
    }
}
