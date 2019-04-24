using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.PersonasLibres
{
    public class GetPersonasLibresResponse : ApplicationResponseBase
    {
        public IEnumerable<PersonaLibreRowViewModel> PersonaLibreRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
