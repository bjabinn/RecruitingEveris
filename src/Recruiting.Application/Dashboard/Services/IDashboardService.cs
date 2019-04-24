using Recruiting.Application.Dashboard.Messages;
using Recruiting.Application.Dashboard.ViewModels;
using System;
using System.Collections.Generic;

namespace Recruiting.Application.Dashboard.Services
{
    public interface IDashboardService
    {       
       
        GetDashboardResponse GetDashboard(List<int> roles, String userName, int? CentroIdUsuario = null, int? usuarioId = null);
        SaveAlertasAdminResponse SaveAlertasAdmin(AlertasAdministradorViewModel alertasAdminViewModel);
    }
}
