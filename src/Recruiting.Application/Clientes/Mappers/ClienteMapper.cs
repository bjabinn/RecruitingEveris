using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Clientes.Mappers
{
    public static class ClienteMapper
    {
        #region Mappers

        public static IEnumerable<ClienteRowViewModel> ConvertToClienteViewModel(this IEnumerable<Cliente> clienteList)
        {
            var clienteRowViewModelList = new List<ClienteRowViewModel>();

            if (clienteList == null)
            {
                return clienteRowViewModelList;
            }

            clienteRowViewModelList = clienteList.Select(x => x.ConvertToClienteRowViewModel()).ToList();

            return clienteRowViewModelList;
        }

        public static ClienteRowViewModel ConvertToClienteRowViewModel(this Cliente cliente)
        {
            var clienteRowViewModel = new ClienteRowViewModel()
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,               
                Activo = cliente.IsActivo
            };

            return clienteRowViewModel;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Centro":
                    attributeName = "Centro.Nombre";
                    break;
            }

            return attributeName;
        }

        public static Cliente Update(this Cliente cliente, ClienteRowViewModel model)
        {
            if (cliente == null)
            {
                cliente = new Cliente(){ IsActivo = true };
            }

            cliente.Nombre = model.Nombre;            

            return cliente;
        }
        #endregion

        #region Private Methods


        #endregion
    }
}
