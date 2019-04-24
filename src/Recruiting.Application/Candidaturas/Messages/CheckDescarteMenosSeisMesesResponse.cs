using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class CheckDescarteMenosSeisMesesResponse : ApplicationResponseBase 
    {
        public bool DescarteMenosSeisMeses { get; set; }
    }
}
