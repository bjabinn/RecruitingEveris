using Recruiting.Application.Base;
using Recruiting.Application.BitacorasNecesidades.ViewModels;

namespace Recruiting.Application.BitacorasNecesidades.Messages
{
    public class GetBitacoraNecesidadByIdResponse : ApplicationResponseBase
    {
        public BitacoraNecesidadRowViewModel BitacoraNecesidadRowViewModel { get; set; }
    }
}
