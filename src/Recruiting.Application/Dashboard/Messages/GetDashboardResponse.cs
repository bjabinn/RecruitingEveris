using Recruiting.Application.Base;
using Recruiting.Application.Dashboard.ViewModels;

namespace Recruiting.Application.Dashboard.Messages
{
    public class GetDashboardResponse: ApplicationResponseBase 
    {
        public DashboardViewModel DashboardViewModel { get; set; }
    
    }   
}
