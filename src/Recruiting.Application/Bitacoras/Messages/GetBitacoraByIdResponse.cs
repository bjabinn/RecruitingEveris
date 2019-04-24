using Recruiting.Application.Base;
using Recruiting.Application.Bitacoras.ViewModels;

namespace Recruiting.Application.Bitacoras.Messages
{
    public class GetBitacoraByIdResponse : ApplicationResponseBase
    {
        public BitacoraRowViewModel BitacoraViewModel { get; set; }
    }
}
