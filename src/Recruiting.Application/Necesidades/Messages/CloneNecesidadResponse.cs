using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;

namespace Recruiting.Application.Necesidades.Messages
{
    public class CloneNecesidadResponse : ApplicationResponseBase
    {
        public CreateEditNecesidadViewModel CreateEditNecesidadViewModel { get; set; }
    }
}
