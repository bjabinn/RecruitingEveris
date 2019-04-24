using Recruiting.Application.Clientes.Messages;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Clientes.Services
{
    public interface IClienteService
    {
        #region Query Request
        GetClientesResponse GetClientes();
        GetClientesResponse GetClientes(DataTableRequest request);
        GetClienteResponse GetCliente(int id);
        SaveClienteResponse SaveCliente(ClienteRowViewModel model);
        SearchClienteUsadoResponse SearchClienteUsado(int clienteId);
        DeleteClienteResponse DeleteCliente(int clienteId);
        bool CheckClienteRepetido(int clienteId, string nombreCliente);
        #endregion
    }
}
