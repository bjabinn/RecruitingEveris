using Recruiting.Application.Base;
using Recruiting.Application.Bitacoras.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Bitacoras.Messages
{
    public class GetBitacorasResponse : ApplicationResponseBase
    {
        public IEnumerable<BitacoraRowViewModel> BitacoraViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
