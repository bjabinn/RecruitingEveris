using Recruiting.Application.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetDropdownCartaOfertaResponse : ApplicationResponseBase
    {
        public List<SelectListItem> plantillas { get; set; }
    }
}
