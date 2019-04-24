using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadByIdResponse : ApplicationResponseBase
    {
        public CreateEditNecesidadViewModel NecesidadViewModel { get; set; }
    }
}
