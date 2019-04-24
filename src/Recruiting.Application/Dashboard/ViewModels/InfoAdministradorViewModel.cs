using System;
using System.Collections.Generic;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class InfoAdministradorViewModel
    {
        public List<EntrevistasFueraFechaRowViewModel> ListPrimeraEntrevistaViewModel { get; set; }
        public List<EntrevistasFueraFechaRowViewModel> ListSegundaEntrevistaViewModel { get; set; }
        public List<EntrevistasFueraFechaRowViewModel> ListCartaOfertaViewModel { get; set; }
        public List<FiltradoPendienteViewModel> ListFiltradoPendienteViewModel { get; set; }
        public List<EntrevistasFueraFechaRowViewModel> ListSubEntrevistasPrimeraEntrevistaViewModel { get; set; }
        public List<EntrevistasFueraFechaRowViewModel> ListSubEntrevistasSegundaEntrevistaViewModel { get; set; }
        public List<CandidaturasPendienteEntrevistaOCartaOfertaViewModel> ListCandidaturasPendienteEntrevistaViewModel { get; set; }
        public List<CandidaturasPendienteEntrevistaOCartaOfertaViewModel> ListCandidaturasPendienteCartaOfertaViewModel { get; set; }
        public List<CandidaturasPendienteStandByViewModel> ListCandidaturasPendienteStandByViewModel { get; set; }
        public List<BecariosPendienteEntrevistaViewModel> ListBecariosPendienteEntrevistaViewModel { get; set; }
        public List<BecariosPendientesStandByViewModel> ListBecariosPendientesStandByViewModel { get; set; }
        public AlertasAdministradorViewModel AlertasAdministradorViewModel { get; set; }

        public string CentroIdUsuarioLogueado { get; set; }
    }
}
