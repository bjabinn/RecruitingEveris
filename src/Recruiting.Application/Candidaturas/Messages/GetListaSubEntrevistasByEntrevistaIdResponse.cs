using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetListaSubEntrevistasByEntrevistaIdResponse : ApplicationResponseBase
    {
        public SubEntrevistaListViewModel subEntrevistalistViewModel { get; set; }
        public int candidaturaId { get; set; }
    }
}
