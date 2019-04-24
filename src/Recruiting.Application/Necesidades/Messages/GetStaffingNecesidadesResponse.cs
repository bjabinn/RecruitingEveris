using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetStaffingNecesidadesResponse : ApplicationResponseBase
    {
        public IEnumerable<StaffingNecesidadRowViewModel> StaffingNecesidadViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
