using Recruiting.Application.Ofertas.Mappers;
using Recruiting.Application.Ofertas.Messages;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Ofertas.Services
{
    public class OfertaService : IOfertaService
    {

        #region Fields

        private readonly IOfertaRepository _ofertaRepository;
        private readonly ICandidaturaRepository _candidaturaRepository;

        #endregion

        #region Constructor

        public OfertaService(IOfertaRepository ofertaRepository, ICandidaturaRepository candidaturaRepository)
        {
            _ofertaRepository = ofertaRepository;
            _candidaturaRepository = candidaturaRepository;
        }

        #endregion

        #region IOfertaService

        public GetOfertasResponse GetOfertas(DataTableRequest request)
        {
            var response = new GetOfertasResponse();

            try
            {

                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, OfertaMapper.GetPropertiePath);

                var ofertaIds = filtered.Select(x => x.OfertaId).ToList();
                var totalCandidatos = new Dictionary<int, int>();
                foreach (var ofertaId in ofertaIds)
                {
                    var count = _candidaturaRepository.CountByCriteria(x => x.OfertaId == ofertaId);
                    totalCandidatos.Add(ofertaId, count);
                }



                response.OfertaViewModel = filtered.ConvertToOfertaRowViewModel(totalCandidatos);
                response.TotalElementos = query.Count();

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetOfertasExportToExcelResponse GetOfertasExportToExcel(DataTableRequest request)
        {
            var response = new GetOfertasExportToExcelResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, OfertaMapper.GetPropertiePath);

                var ofertaIds = filtered.Select(x => x.OfertaId).ToList();
                var totalCandidatos = new Dictionary<int, int>();
                foreach (var ofertaId in ofertaIds)
                {
                    var count = _candidaturaRepository.CountByCriteria(x => x.OfertaId == ofertaId);
                    totalCandidatos.Add(ofertaId, count);
                }

                response.OfertaViewModel = filtered.ConvertToOfertaRowExportToExcelViewModel(totalCandidatos);
                response.TotalElementos = query.Count();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetOfertasNombreIdResponse GetOfertasNombreId(int? centroId = null)
        {
            var response = new GetOfertasNombreIdResponse();
            try
            {
                IEnumerable<Oferta> ofertas;
                if (centroId.HasValue)
                {
                    ofertas = _ofertaRepository.GetByCriteria(x => x.IsActivo && x.Usuario.CentroId == centroId);
                }
                else
                {
                    ofertas = _ofertaRepository.GetByCriteria(x => x.IsActivo);
                }
                response.OfertaNombreIdViewModel = ofertas.ConvertToOfertaNombreIdViewModel();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public GetOfertasResponse GetOfertas()
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();

            return GetOfertas(request);
        }

        public GetOfertasResponse GetOfertasByCentroUsuarioId(int CentroUsuarioId)
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();
            request.CustomFilters.Add("CentroUsuarioId", CentroUsuarioId.ToString());
            request.CustomFilters.Add("Buscar", "true");

            return GetOfertas(request);

        }

        public GetOfertaByIdResponse GetOfertaById(int ofertaId)
        {
            var response = new GetOfertaByIdResponse();

            try
            {
                response.OfertaViewModel = OfertaMapper.ConvertToCreateEditOfertaViewModel(_ofertaRepository.GetOne(x => x.OfertaId == ofertaId));
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SaveOfertaResponse SaveOferta(CreateEditOfertaViewModel ofertaViewModel)
        {
            var response = new SaveOfertaResponse();

            try
            {
                if (ofertaViewModel.OfertaId == null)
                {
                    var newOferta = Save(ofertaViewModel);
                    if (newOferta != null)
                    {
                        response.IsValid = true;
                        response.OfertaId = newOferta.OfertaId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to save Oferta";
                    }
                }
                else
                {
                    if (Update(ofertaViewModel) > 0)
                    {
                        response.IsValid = true;
                        response.OfertaId = (int)ofertaViewModel.OfertaId;
                    }
                    else
                    {
                        response.IsValid = false;
                        response.ErrorMessage = "Error to update Oferta";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public DeleteOfertaResponse DeleteOferta(int ofertaId)
        {
            var response = new DeleteOfertaResponse();

            try
            {
                var oferta = _ofertaRepository.GetOne(x => x.OfertaId == ofertaId);

                oferta.IsActivo = false;

                if (_ofertaRepository.Update(oferta) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to delete Oferta";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetOfertasByNameAndCentroResponse GetOfertasByNameAndCentro(string textSearch, int? centroId)
        {
            var response = new GetOfertasByNameAndCentroResponse();
            response.Ofertas = new List<OfertaRowViewModel>();
            try
            {
                var listaOfertas = _ofertaRepository.GetByCriteria(x => x.Nombre.ToLower().Contains(textSearch.ToLower()) && x.IsActivo);
                if (centroId.HasValue)
                {
                    listaOfertas = listaOfertas.Where(x => x.Usuario.CentroId == centroId.Value).OrderBy(x => x.Nombre);
                }
                response.Ofertas = listaOfertas.ConvertToOfertaRowViewModelSinCandidatos().ToList();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        #endregion

        #region Private Methods

        private Oferta Save(CreateEditOfertaViewModel createEditOfertaViewModel)
        {
            var oferta = new Oferta();

            oferta.UpdateOferta(createEditOfertaViewModel);

            var newOferta = _ofertaRepository.Create(oferta);

            return newOferta;
        }

        private int Update(CreateEditOfertaViewModel createEditOfertaViewModel)
        {
            var oferta = _ofertaRepository.GetOne(x => x.OfertaId == createEditOfertaViewModel.OfertaId);

            oferta.UpdateOferta(createEditOfertaViewModel);

            return _ofertaRepository.Update(oferta);
        }

        private IQueryable<Oferta> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _ofertaRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Nombre") && (customFilter["Nombre"] != string.Empty))
            {
                    var nombre = customFilter["Nombre"];
                    query = query.Where(x => x.Nombre.Contains(nombre));
            }

            if (customFilter.ContainsKey("Descripcion") && (customFilter["Descripcion"] != string.Empty))
            {
                    var descripcion = customFilter["Descripcion"];
                    query = query.Where(x => x.Descripcion.Contains(descripcion));
            }

            if (customFilter.ContainsKey("Estado") && (customFilter["Estado"] != string.Empty))
            {
                    var estadoOfertaId = Convert.ToInt32(customFilter["Estado"]);
                    query = query.Where(x => x.EstadoOfertaId == estadoOfertaId);
            }

            if (customFilter.ContainsKey("PublicadaDesde") && (customFilter["PublicadaDesde"] != string.Empty))
            {
                    var fechaPublicacion = Convert.ToDateTime(customFilter["PublicadaDesde"]);
                    query = query.Where(x => x.FechaPublicacion >= fechaPublicacion);
            }

            if (customFilter.ContainsKey("PublicadaHasta") && (customFilter["PublicadaHasta"] != string.Empty))
            {
                    var fechaPublicacion = Convert.ToDateTime(customFilter["PublicadaHasta"]);
                    query = query.Where(x => x.FechaPublicacion <= fechaPublicacion);
            }


            //se filtra por el centro del usuario logado salvo cuando hay un Centro de busqueda que buscaria los del centro en cuestion (CentroSearch)
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty || customFilter.ContainsKey("CentroSearch")))
            {
                    if (customFilter.ContainsKey("CentroSearch"))
                    {
                        if (customFilter["CentroSearch"] != string.Empty)
                        {
                            var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                            query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                        }
                        else
                        {
                            if (customFilter["CentroUsuarioId"] != string.Empty)
                            {
                                var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                                query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                            }
                        }
                    }
                    else
                    {
                        var CentroUsuarioId = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                        query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
                    }
            }

            if (customFilter.ContainsKey("CentroSearch") && !customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroSearch"] != string.Empty))
            {
                    var CentroUsuarioId = Convert.ToInt32(customFilter["CentroSearch"]);
                    query = query.Where(x => x.Usuario.Centro.CentroId == CentroUsuarioId);
            }

            return query;

        }

        #endregion
    }
}
