using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetStaffingPersonasResponse : ApplicationResponseBase
    {
        public IEnumerable<StaffingPersonaRowViewModel> StaffingPersonaViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
