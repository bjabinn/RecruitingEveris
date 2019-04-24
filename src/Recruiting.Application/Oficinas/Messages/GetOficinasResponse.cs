using Recruiting.Application.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Oficinas.Messages
{
    public class GetOficinasResponse : ApplicationResponseBase
    {
        public IEnumerable<SelectListItem> ListaOficinasIdNombre { get; set; }
    }
}
