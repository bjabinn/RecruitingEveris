using System;
using System.Collections.Generic;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class DashboardViewModel
    {
        public InfoAdministradorViewModel InfoAdministradorViewModel { get; set; }
        public InfoEntrevistadorViewModel InfoEntrevistadorViewModel { get; set; }   
        public IEnumerable<int> RolsId { get; set; }
        
        public int? UsuarioIdLogueado { get; set; }
    }
}
