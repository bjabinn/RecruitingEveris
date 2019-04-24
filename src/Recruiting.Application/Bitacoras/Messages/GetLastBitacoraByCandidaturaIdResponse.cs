using Recruiting.Application.Base;
using Recruiting.Application.Bitacoras.ViewModels;

namespace Recruiting.Application.Bitacoras.Messages
{
    public class GetLastBitacoraByCandidaturaIdResponse : ApplicationResponseBase
    {
        public BitacoraCorreoViewModel BitacoraCorreoViewModel { get; set; }
    }
}
