using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;

namespace Recruiting.Application.PersonasLibres.Messages
{
    public class GetListCategoriaLineaCeldaResponse : ApplicationResponseBase
    {
        public PersonasLibresListCategoriaLineaCeldaviewModel PersonasLibresListCategoriaLineaCeldaviewModel { get; set; }
    }
}
