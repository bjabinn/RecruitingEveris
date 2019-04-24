using System;
using System.Collections.Generic;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class InfoEntrevistadorViewModel
    {
        public List<EntrevistasPlanificadasRowViewModel> ListEntrevistasPlanificadasViewModel { get; set; }
        public List<FiltradoPendienteViewModel> ListFiltradoPendienteViewModel { get; set; }
    }
}
