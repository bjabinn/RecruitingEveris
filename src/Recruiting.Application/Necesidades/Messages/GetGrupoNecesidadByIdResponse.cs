using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetGrupoNecesidadByIdResponse : ApplicationResponseBase
    {
        public CreateEditGrupoNecesidadViewModel GrupoNecesidadViewModel { get; set; }
    }
}
