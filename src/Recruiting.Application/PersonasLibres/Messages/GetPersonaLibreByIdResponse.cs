using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;

namespace Recruiting.Application.PersonasLibres.Messages
{
    public class GetPersonaLibreByIdResponse : ApplicationResponseBase
    {
        public CreateEditPersonaLibreViewModel PersonaLibreViewModel { get; set; }
    }
}
