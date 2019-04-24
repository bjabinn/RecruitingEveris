using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
namespace Recruiting.Application.Becarios.Messages
{
    public class EditBecarioResponse : ApplicationResponseBase
    {
        public CreateEditBecarioViewModel becario { get; set; }
    }
}
