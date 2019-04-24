using Recruiting.Application.Base;
using Recruiting.Application.BitacorasBecarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.BitacorasBecarios.Messages
{
    public class GetBitacorasBecarioResponse : ApplicationResponseBase
    {
        public IEnumerable<BitacoraBecariosRowViewModel> BitacoraBecarioRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
