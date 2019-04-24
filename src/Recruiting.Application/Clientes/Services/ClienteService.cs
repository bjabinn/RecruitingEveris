using Recruiting.Application.Clientes.Mappers;
using Recruiting.Application.Clientes.Messages;
using Recruiting.Application.Clientes.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Recruiting.Application.Clientes.Services
{
    public class ClienteService : IClienteService
    {
        #region Fields

        private readonly IClienteRepository _clienteRepository;
        private readonly IProyectoRepository _proyectoRepository;

        #endregion

        #region Constructors

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _proyectoRepository = new ProyectoRepository();
        }

        #endregion

        #region IClienteRepository Members
        public GetClientesResponse GetClientes()
        {
            var response = new GetClientesResponse();

            try
            {
                response.ClienteViewModel = ClienteMapper.ConvertToClienteViewModel(_clienteRepository.GetByCriteria(x => x.IsActivo).OrderBy(x => x.Nombre));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetClientesResponse GetClientes(DataTableRequest request)
        {
            var response = new GetClientesResponse() { IsValid = true };

            try
            {
                //establecer los filtros
                var query = Filter(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, ClienteMapper.GetPropertiePath);


                response.ClienteViewModel = filtered.ConvertToClienteViewModel();
                response.TotalElementos = query.Count();
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetClienteResponse GetCliente(int id)
        {
            var response = new GetClienteResponse() { IsValid = true };

            try
            {
                var cliente = _clienteRepository.GetOne(x => x.ClienteId == id);
                response.Cliente = cliente.ConvertToClienteRowViewModel();
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveClienteResponse SaveCliente(ClienteRowViewModel model)
        {
            var response = new SaveClienteResponse() { IsValid = true, ErrorMessage = "Cliente guardado correctamente." };

            try
            {
                var cliente = _clienteRepository.GetOne(x => x.ClienteId == model.ClienteId);
                cliente = cliente.Update(model);

                if (cliente.ClienteId == 0)
                {
                    _clienteRepository.Create(cliente);
                }
                else
                {
                    _clienteRepository.Update(cliente);
                }

                response.ClienteId = cliente.ClienteId;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public bool CheckClienteRepetido(int clienteId, string nombreCliente)
        {
            var response = _clienteRepository.GetByCriteria(x=> x.IsActivo);

            foreach (var clienteExistente in response)
            {
                var nombreClienteExistente = clienteExistente.Nombre.Replace(" ", "").ToLower().RemoveDiacritics();
                var nombreClienteNuevo = nombreCliente.Replace(" ", "").ToLower().RemoveDiacritics();
                if (nombreClienteExistente.Equals(nombreClienteNuevo) && (clienteId != clienteExistente.ClienteId))
                {
                        return true;                  
                }
            }
            return false;
        }

        public SearchClienteUsadoResponse SearchClienteUsado(int clienteId)
        {
            var response = new SearchClienteUsadoResponse();

            try
            {
                var proyectoUsandoCliente = _proyectoRepository.Find(x => x.IsActivo && x.ClienteId == clienteId);
                if (proyectoUsandoCliente == null)
                {
                    response.Usado = false;
                }
                else
                {
                    response.Usado = true;
                }
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DeleteClienteResponse DeleteCliente(int clienteId)
        {
            var response = new DeleteClienteResponse() { IsValid = true };

            try
            {
                var cliente = _clienteRepository.GetOne(x => x.ClienteId == clienteId);
                if (cliente != null)
                {
                    cliente.IsActivo = false;
                    _clienteRepository.Update(cliente);
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        #endregion

        #region Private

        private IQueryable<Cliente> Filter(IDictionary<string, string> customFilter)
        {

            Expression<Func<Cliente, bool>> criteria = x => x.IsActivo;

            if (customFilter.ContainsKey("Nombre"))
            {
                var filtro = customFilter["Nombre"];
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    criteria = criteria.And(x => x.Nombre.Contains(filtro));
                }
            }

            var query = _clienteRepository.GetByCriteria(criteria);

            return query;
        }
        #endregion
    }
}
