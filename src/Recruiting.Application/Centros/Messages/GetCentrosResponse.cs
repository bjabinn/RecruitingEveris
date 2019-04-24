using Recruiting.Application.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Centros.Messages
{
    public class GetCentrosResponse : ApplicationResponseBase
    {
        public IEnumerable<SelectListItem> ListaCentrosIdNombre { get; set; }
    }
}
