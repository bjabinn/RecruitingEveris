using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class CheckNoMotivadoCambioEmpresaResponse : ApplicationResponseBase 
    {
        public bool NoMotivadoCambioEmpresa { get; set; }
    }
}
