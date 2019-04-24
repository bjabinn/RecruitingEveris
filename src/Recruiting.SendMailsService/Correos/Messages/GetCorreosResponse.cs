using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Correos.Messages
{
    public class GetCorreosResponse : ApplicationResponseBase
    {
        public IEnumerable<CorreoRowViewModel> CorreoViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
