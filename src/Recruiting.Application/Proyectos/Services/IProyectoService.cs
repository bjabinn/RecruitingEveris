using Recruiting.Application.Proyectos.Messages;
using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Proyectos.Services
{
    public interface IProyectoService
    {
        #region Query Request

        GetProyectoResponse GetProyecto(int proyectoId);
        GetProyectosResponse GetProyectos();
        GetProyectosResponse GetProyectos(DataTableRequest request);
        GetProyectosByClienteResponse GetProyectosByCliente(int? clienteId);
        SaveProyectoResponse SaveProyecto(ProyectoRowViewModel model);
        SearchProyectoUsadoResponse SearchProyectoUsado(int proyectoId);
        DeleteProyectoResponse DeleteProyecto(int proyectoId);
        GetProyectosNombreIdResponse GetProyectosNombreId();
        GetSectorServicioClienteFromProyectoResponse GetSectorServicioClienteFromProyecto(int? proyectoId);
        #endregion
    }
}
