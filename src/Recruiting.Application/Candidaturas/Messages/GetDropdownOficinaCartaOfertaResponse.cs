using Recruiting.Application.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetDropdownOficinaCartaOfertaResponse : ApplicationResponseBase
    {
        public List<SelectListItem> oficinas { get; set; }
    }
}
