using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Business.Entities;
using System;
using System.Configuration;
using System.Linq;

namespace Recruiting.Application.Candidaturas.Mappers
{
    public static class CandidaturaSegundaEntrevistaMapper
    {
        #region Mapper

        public static SegundaEntrevistaViewModel ConvertToSegundaEntrevistaViewModel(this Candidatura candidatura)
        {
            Entrevista segundaEntrevista;
            int? motivoSegundaEntrevista = null;
            string motivoNombreSegundaEntrevista = "";
            bool superaSegundaEntrevista = false;
            bool sinDecidir = false;
            SegundaEntrevistaViewModel segundaEntrevistaViewModel = new SegundaEntrevistaViewModel();            

            if (candidatura.Entrevistas != null && (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)))
            {
                    segundaEntrevista = candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista);
                    motivoSegundaEntrevista = segundaEntrevista.MotivoId ?? null;
                    motivoNombreSegundaEntrevista = segundaEntrevista.Motivo?.Nombre;
                    superaSegundaEntrevista = segundaEntrevista.SuperaEntrevista;
                    sinDecidir = segundaEntrevista.SinDecision;

                    segundaEntrevistaViewModel = new SegundaEntrevistaViewModel()
                    {
                        AgendarSegundaEntrevista = segundaEntrevista.ConvertToAgendarSegundaEntrevistaViewModel(),

                        RangoSalarialesyDisponibilidades = candidatura.GetRangoSalarialesyDisponibilidades(),

                        ResultadoSegundaEntrevista = candidatura.GetResultadoSegundaEntrevista(motivoSegundaEntrevista, motivoNombreSegundaEntrevista, superaSegundaEntrevista, sinDecidir),
                    };
            }

            if (candidatura.CartaOfertas != null && (candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.Fin) 
                    && (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta
                     || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Contratado || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado
                     || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia))
            {
                segundaEntrevistaViewModel.MostrarRangosSalariales = false;
            }
            else
            {
                segundaEntrevistaViewModel.MostrarRangosSalariales = true;
            }

            return segundaEntrevistaViewModel;
        }

        public static void UpdateCandidaturaSegundaEntrevista(this Entrevista entrevista, AgendarSegundaEntrevistaViewModel agendarSegundaEntrevistaViewModel, int? entrevistaId)
        {
            if (entrevistaId != null)
            {
                entrevista.EntrevistaId = (int)entrevistaId;
                
                entrevista.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                entrevista.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                entrevista.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                entrevista.Created = ModifiableEntityHelper.GetCurrentDate();
            }
            if (agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.EntrevistadorId > 0) {
                 entrevista.EntrevistadorId = agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.EntrevistadorId;
            }
            entrevista.FechaEntrevista = (DateTime)agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.FechaEntrevista;
            entrevista.Presencial = agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.Presencial;
            entrevista.AvisarAlCandidato = agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.AvisarAlCandidato;
            entrevista.CandidaturaId = agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.CandidaturaId;
            entrevista.TipoEntrevistaId = (int)TipoEntrevistaEnum.SegundaEntrevista;
            entrevista.OficinaId = agendarSegundaEntrevistaViewModel.AgendarSegundaEntrevista.OficinaId;
            entrevista.IsActivo = true;
        }

        public static void UpdateCandidaturaSegundaEntrevista(this Entrevista entrevista, SegundaEntrevistaViewModel segundaEntrevistaViewModel, int? entrevistaId)
        {
            if (entrevistaId != null)
            {
                entrevista.EntrevistaId = (int)entrevistaId;

                entrevista.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                entrevista.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                entrevista.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                entrevista.Created = ModifiableEntityHelper.GetCurrentDate();
            }
            if (segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                entrevista.Observaciones = segundaEntrevistaViewModel.RangoSalarialesyDisponibilidades.ObservacionesEntrevista;
            }
            if (segundaEntrevistaViewModel.ResultadoSegundaEntrevista != null)
            {
                entrevista.SuperaEntrevista = segundaEntrevistaViewModel.ResultadoSegundaEntrevista.SuperaEntrevista2Id.Value == (int)TipoDecisionEnum.SUPERA_SEGUNDA_ENTREVISTA;
                entrevista.SinDecision = segundaEntrevistaViewModel.ResultadoSegundaEntrevista.SuperaEntrevista2Id.Value == (int)TipoDecisionEnum.SIN_DECIDIR_SEGUNDA_ENTREVISTA;
                entrevista.MotivoId = segundaEntrevistaViewModel.ResultadoSegundaEntrevista.MotivoId;                
            }
        }

        #region Private Methods

        private static RangoSalarialesyDisponibilidades GetRangoSalarialesyDisponibilidades(this Candidatura candidatura)
        {
            if (candidatura.CategoriaId != null)
            {
                return new RangoSalarialesyDisponibilidades()
                {
                    CategoriaId = (int)candidatura.CategoriaId,
                    CategoriaNombre = candidatura.Categoria?.Nombre,
                    SalarioPropuesto = candidatura.SalarioPropuesto,
                    SalarioActual = candidatura.SalarioActual,
                    DisponibilidadViajes = candidatura.DisponibilidadViajes,
                    CambioResidencia = candidatura.CambioResidencia,
                    IncorporacionId = candidatura.IncorporacionId,
                    IncorporacionNombre = candidatura.Incorporacion?.Nombre,
                    ObservacionesEntrevista = candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista).Observaciones,
                    SalarioDeseado = candidatura.SalarioDeseado,
                    Moneda = candidatura.Moneda
                };
            }
            else
            {
                return null;
            }
        }

        private static ResultadoSegundaEntrevista GetResultadoSegundaEntrevista(this Candidatura candidatura, int? motivoSegundaEntrevista, string motivoNombreSegundaEntrevista, bool superaSegundaEntrevista, bool sinDecidir)
        {
            return new ResultadoSegundaEntrevista()
            {
                MotivoId = motivoSegundaEntrevista,
                MotivoNombre = motivoNombreSegundaEntrevista,
                SuperaEntrevista2Id = sinDecidir ? (int)TipoDecisionEnum.SIN_DECIDIR_SEGUNDA_ENTREVISTA : (superaSegundaEntrevista ? (int)TipoDecisionEnum.SUPERA_SEGUNDA_ENTREVISTA : (int)TipoDecisionEnum.NO_SUPERA_SEGUNDA_ENTREVISTA),
                NotificarDescarte = candidatura.NotificarDescarte
            };
        }

        private static AgendarSegundaEntrevistaViewModel ConvertToAgendarSegundaEntrevistaViewModel(this Entrevista entrevista)
        {
            var agendarSegundaEntrevistaViewModel = new AgendarSegundaEntrevistaViewModel()
            {
                AgendarSegundaEntrevista = new AgendarSegundaEntrevista()
                {
                    CandidaturaId = entrevista.CandidaturaId,
                    EntrevistadorId = entrevista.EntrevistadorId,
                    FechaEntrevista = entrevista.FechaEntrevista,
                    Presencial = entrevista.Presencial,
                    AvisarAlCandidato = entrevista.AvisarAlCandidato,
                    EntrevistadorName = entrevista.Entrevistador == null ? string.Empty : entrevista.Entrevistador.Nombre,
                    OficinaId = entrevista.OficinaId,
                    PlantillaCorreoNombre = entrevista.OficinaId == null ? "Genérica" : entrevista.Oficina?.Nombre,
                    NombreCandidato = entrevista.Candidatura.Candidato.Nombre + " " + entrevista.Candidatura.Candidato.Apellidos
                }

            };

            int nSubEntrevistas = Convert.ToInt16(ConfigurationManager.AppSettings["numeroMaximoSubEntrevistas"].ToString());
            var listaSubEntrevistas = entrevista.SubEntrevista.Where(y => y.IsActivo).Select(x => CandidaturaSubEntrevistaMapper.ConvertToSubEntrevistaViewModel(x)).ToList();
            var numeroDeSubEntrevistas = listaSubEntrevistas.Count;
            if (numeroDeSubEntrevistas < nSubEntrevistas)
            {
                for (var i = 1; i <= nSubEntrevistas - numeroDeSubEntrevistas; i++)
                {
                    var subEntrevistaVacia = new SubEntrevistaViewModel();
                    listaSubEntrevistas.Add(subEntrevistaVacia);
                }
            }
            agendarSegundaEntrevistaViewModel.SubEntrevistaList = listaSubEntrevistas;

            return agendarSegundaEntrevistaViewModel;
        }

        #endregion

        #endregion
    }
}
