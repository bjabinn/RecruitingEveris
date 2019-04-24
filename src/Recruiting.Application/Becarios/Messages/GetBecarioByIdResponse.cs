using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetBecarioByIdResponse : ApplicationResponseBase
    {
        public CreateEditBecarioViewModel BecarioViewModel { get; set; }
    }
}
