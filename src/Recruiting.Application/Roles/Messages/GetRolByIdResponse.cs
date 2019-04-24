using Recruiting.Application.Base;
using Recruiting.Application.Roles.ViewModels;

namespace Recruiting.Application.Roles.Messages
{
    public class GetRolByIdResponse : ApplicationResponseBase
    {
        public CreateEditRolViewModel RolViewModel { get; set; }
    }
}
