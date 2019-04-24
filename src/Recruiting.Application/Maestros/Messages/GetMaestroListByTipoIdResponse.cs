using Recruiting.Application.Base;
using Recruiting.Application.Maestros.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Maestros.Messages
{
    public class GetMaestroListByTipoIdResponse : ApplicationResponseBase
    {
        public IEnumerable<MaestroRowViewModel> DatosMaestroCollection { get; set; }
        public int TotalElementos { get; set; }
    }
}
