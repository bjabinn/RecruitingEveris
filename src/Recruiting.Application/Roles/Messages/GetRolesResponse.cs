using Recruiting.Application.Base;
using Recruiting.Application.Roles.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Roles.Messages
{
    public class GetRolesResponse : ApplicationResponseBase
    {
        public IEnumerable<RolRowViewModel> RolViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
