using Recruiting.Application.Base;
using Recruiting.Application.Ofertas.ViewModels;

namespace Recruiting.Application.Ofertas.Messages
{
    public class GetOfertaByIdResponse : ApplicationResponseBase
    {
        public CreateEditOfertaViewModel OfertaViewModel { get; set; }
    }
}
