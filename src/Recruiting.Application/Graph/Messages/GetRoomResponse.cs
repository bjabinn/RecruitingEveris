using Recruiting.Application.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Graph.Messages
{
    public class GetRoomResponse : ApplicationResponseBase
    {
        public List<SelectListItem> salas { get; set; }
    }
}