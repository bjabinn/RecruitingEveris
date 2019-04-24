using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Application.Helpers;
using Recruiting.Business.Entities;
using System;
using System.Configuration;
using System.Linq;

namespace Recruiting.Application.Candidaturas.Mappers
{
    public static class CandidaturaPrimeraEntrevistaMapper
    {
        #region Mapper
        public static PrimeraEntrevistaViewModel ConvertToPrimeraEntrevistaViewModel(this Candidatura candidatura)
        {
            Entrevista primeraEntrevista;
            string observaciones = "";
            int? motivoPrimeraEntrevista = null;
            string motivoNombrePrimeraEntrevista = "";
            bool superaPrimeraEntrevista = false;
            bool sinDecidir = false;
            bool completada = false;
            int? resultadoPrimeraEntrevista = null;
			byte[] TS = null;
            string NombreTS = "";

            PrimeraEntrevistaViewModel primeraEntrevistaViewModel = new PrimeraEntrevistaViewModel();
            
            if (candidatura.Entrevistas != null && (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista)))
            {
                    primeraEntrevista = candidatura.Entrevistas.Single(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.PrimeraEntrevista);
                    observaciones = primeraEntrevista.Observaciones ?? "";
                    motivoPrimeraEntrevista = primeraEntrevista.MotivoId ?? null;
                    motivoNombrePrimeraEntrevista = primeraEntrevista.Motivo?.Nombre;
                    superaPrimeraEntrevista = primeraEntrevista.SuperaEntrevista;
                    sinDecidir = primeraEntrevista.SinDecision;
                    resultadoPrimeraEntrevista = primeraEntrevista.ResultadoTest ?? null;
					TS = primeraEntrevista.TS;
                    NombreTS = primeraEntrevista.NombreTS;
                    


                    primeraEntrevistaViewModel = new PrimeraEntrevistaViewModel()
                    {
                        AgendarPrimeraEntrevista = primeraEntrevista.ConvertToAgendarPrimeraEntrevistaViewModel(),

                        RangoSalarialesyDisponibilidades = candidatura.GetRangoSalarialesyDisponibilidades(observaciones),

                        ResultadoPrimeraEntrevista = candidatura.GetResultadoPrimeraEntrevista(motivoPrimeraEntrevista,motivoNombrePrimeraEntrevista, superaPrimeraEntrevista, sinDecidir, resultadoPrimeraEntrevista,NombreTS,TS,completada),
                    };
            }

            if(candidatura.Entrevistas != null && (candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.SegundaEntrevista
                || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.CartaOferta
                || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Descartado 
                || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Renuncia
                || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.RechazaOferta
                || candidatura.EstadoCandidaturaId == (int)TipoEstadoCandidaturaEnum.Contratado) &&
                (candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackSegundaEntrevista
                || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.AgendarCartaOferta
                || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.PendienteDecisionCartaOferta
                || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.FeedbackCartaOferta
                || candidatura.EtapaCandidaturaId == (int)TipoEtapaCandidaturaEnum.Fin)
                && (candidatura.Entrevistas.Any(x => x.TipoEntrevistaId == (int)TipoEntrevistaEnum.SegundaEntrevista)))
            {
                primeraEntrevistaViewModel.MostrarRangosSalariales = false;
            }
            else
            {
                primeraEntrevistaViewModel.MostrarRangosSalariales = true;
            }

            return primeraEntrevistaViewModel;
        }

        public static void UpdateCandidaturaPrimeraEntrevista(this Entrevista entrevista, AgendarPrimeraEntrevistaViewModel agendarPrimeraEntrevistaViewModel, int? entrevistaId)
        {
            if(entrevistaId != null)
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
            if (agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.EntrevistadorId != 0)
            {
                entrevista.EntrevistadorId = agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.EntrevistadorId;
            }
            entrevista.FechaEntrevista = (DateTime)agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.FechaEntrevista;
            entrevista.Presencial = agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.Presencial;
            entrevista.AvisarAlCandidato = agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.AvisarAlCandidato;
            entrevista.CandidaturaId = agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.CandidaturaId;
            entrevista.TipoEntrevistaId = (int)TipoEntrevistaEnum.PrimeraEntrevista;
            entrevista.IsActivo = true;
            if (entrevista.Candidatura == null || entrevista.Candidatura.EtapaCandidaturaId != (int)TipoEtapaCandidaturaEnum.FeedbackPrimeraEntrevista)
            {
                entrevista.OficinaId = agendarPrimeraEntrevistaViewModel.AgendarPrimeraEntrevista.OficinaId;
            }
        }

        public static void UpdateCandidaturaPrimeraEntrevista(this Entrevista entrevista, PrimeraEntrevistaViewModel primeraEntrevistaViewModel, int? entrevistaId)
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
            if (primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades != null)
            {
                entrevista.Observaciones = primeraEntrevistaViewModel.RangoSalarialesyDisponibilidades.ObservacionesEntrevista;
            }
            if (primeraEntrevistaViewModel.ResultadoPrimeraEntrevista != null)
            {
             
                entrevista.SuperaEntrevista = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.SuperaEntrevistaId.Value == (int)TipoDecisionEnum.SUPERA_PRIMERA_ENTREVISTA;
                entrevista.SinDecision = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.SuperaEntrevistaId.Value == (int)TipoDecisionEnum.SIN_DECIDIR_PRIMERA_ENTREVISTA;
               
                entrevista.ResultadoTest = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.ResultadoTest;
                entrevista.MotivoId = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.MotivoId;

                if(primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS != null)
                {
                    entrevista.TS = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.TS;
                    entrevista.NombreTS = primeraEntrevistaViewModel.ResultadoPrimeraEntrevista.NombreTS;
                }           
            }
        }


        #region Private Methods

        private static AgendarPrimeraEntrevistaViewModel ConvertToAgendarPrimeraEntrevistaViewModel(this Entrevista entrevista)
        {
            var agendarPrimeraEntrevistaViewModel = new AgendarPrimeraEntrevistaViewModel()
            {
                AgendarPrimeraEntrevista = new AgendarPrimeraEntrevista()
                {
                    CandidaturaId = entrevista.CandidaturaId,
                    EntrevistadorId = (int)entrevista.EntrevistadorId,
                    FechaEntrevista = entrevista.FechaEntrevista,
                    Presencial = entrevista.Presencial,
                    AvisarAlCandidato = entrevista.AvisarAlCandidato,
                    EntrevistadorName = entrevista.Entrevistador == null ? string.Empty : entrevista.Entrevistador.Nombre,
                    OficinaId = entrevista.OficinaId,
                    PlantillaCorreoNombre = entrevista.OficinaId == null ? "Genérica" : entrevista.Oficina?.Nombre,
                    NombreCandidato = entrevista.Candidatura.Candidato.Nombre + " " + entrevista.Candidatura.Candidato.Apellidos
                },
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
            agendarPrimeraEntrevistaViewModel.SubEntrevistaList = listaSubEntrevistas;

            return agendarPrimeraEntrevistaViewModel;
        }

        private static RangoSalarialesyDisponibilidades GetRangoSalarialesyDisponibilidades(this Candidatura candidatura, string observaciones)
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
                    ObservacionesEntrevista = observaciones,
                    SalarioDeseado = candidatura.SalarioDeseado,
                    Moneda = candidatura.Moneda,
                };
            }
            else
            {
                return new RangoSalarialesyDisponibilidades();
            }
        }

        private static ResultadoPrimeraEntrevista GetResultadoPrimeraEntrevista(this Candidatura candidatura, int? motivoPrimeraEntrevista, string motivoNombrePrimeraEntrevista, bool superaPrimeraEntrevista, bool sinDecidir, int? resultadoPrimeraEntrevista, string NombreTS, byte[] TS, bool completada)
        {
            return new ResultadoPrimeraEntrevista()
            {
                MotivoId = motivoPrimeraEntrevista,
                MotivoNombre = motivoNombrePrimeraEntrevista,
                SuperaEntrevistaId = sinDecidir ? (int)TipoDecisionEnum.SIN_DECIDIR_PRIMERA_ENTREVISTA : (superaPrimeraEntrevista ? (int)TipoDecisionEnum.SUPERA_PRIMERA_ENTREVISTA : (int)TipoDecisionEnum.NO_SUPERA_PRIMERA_ENTREVISTA),
                ResultadoTest = resultadoPrimeraEntrevista,
				NombreTS = NombreTS,
                TS = TS,
                subidoTS = (TS != null),
                Completada = completada  ,
                NotificarDescarte = candidatura.NotificarDescarte              
        };
        }


        #endregion

        #endregion
    }
}
