using Recruiting.Application.Base;
using Recruiting.Application.BitacorasNecesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.BitacorasNecesidades.Messages
{
    public class GetBitacorasNecesidadResponse : ApplicationResponseBase
    {
        public IEnumerable<BitacoraNecesidadRowViewModel> BitacoraNecesidadRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
