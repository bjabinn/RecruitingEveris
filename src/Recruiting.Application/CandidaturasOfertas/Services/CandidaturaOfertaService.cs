using Recruiting.Application.CandidaturasOfertas.Mappers;
using Recruiting.Application.CandidaturasOfertas.Messages;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.CandidaturasOfertas.Services
{
    public class CandidaturaOfertaService: ICandidaturaOfertaService
    {
        #region Constants

        #endregion

        #region Fields

        private readonly ICandidaturaOfertaRepository _candidaturaOfertaRepository;  
        private readonly ICandidaturaRepository _candidaturaRepository; 

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CandidaturaOfertaService(ICandidaturaOfertaRepository candidaturaOfertaRepository)
        {
            _candidaturaOfertaRepository = candidaturaOfertaRepository;
            _candidaturaRepository = new CandidaturaRepository();
        }

        #endregion

        #region PublicMethods


        public SaveOfertaResponse SaveOferta(int idOferta, string nombreOferta, int centroId)
        {
            var response = new SaveOfertaResponse();

            try
            {

                var oferta = _candidaturaOfertaRepository.GetOne(x => x.CandidaturaOfertaId == idOferta && x.IsActivo);

                if(oferta == null)
                {
                    CandidaturaOferta nuevaOferta = new CandidaturaOferta()
                    {
                        NombreOferta = nombreOferta,
                        CentroId = centroId,
                        IsActivo = true
                    };

                    _candidaturaOfertaRepository.Create(nuevaOferta);
                }
                else
                {
                    oferta.NombreOferta = nombreOferta;
                    oferta.CentroId = centroId;
                    _candidaturaOfertaRepository.Update(oferta);

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

        public GetOfertasResponse GetOfertas(DataTableRequest request)
        {
            var response = new GetOfertasResponse();

            try
            {               
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, CandidaturaOfertaMapper.GetPropertiePath);

                response.OfertaRowViewModel = filtered.ConvertToOfertaViewModel();
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

        public RemoveOfertaResponse RemoveOferta(int ofertaId)
        {
            var response = new RemoveOfertaResponse();
            try
            {
                var ofertaBorrar = _candidaturaOfertaRepository.GetOne(x => x.CandidaturaOfertaId == ofertaId);
                //cambiamos el activo a =0(borrado lógico)
                ofertaBorrar.IsActivo = false;
                if (_candidaturaOfertaRepository.Update(ofertaBorrar) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error deleting Oferta";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SearchOfertaByNombreCentroIdResponse SearchOfertaByNombreCentroId(string nombreOferta, int centroId)
        {
            var response = new SearchOfertaByNombreCentroIdResponse();

            try
            {
                nombreOferta = nombreOferta.RemoveDiacritics().ToLower();
               
                var oferta = _candidaturaOfertaRepository.GetOne(x => x.NombreOferta.ToLower().Equals(nombreOferta)
                                                            && x.CentroId == centroId
                                                            && x.IsActivo);

                if (oferta == null || !oferta.IsActivo)
                {
                    response.IsValid = true;
                }
                else if (oferta.IsActivo)
                {
                    response.IsValid = false;
                    response.ErrorMessage = string.Format("Ya existe alguna oferta con el nombre: {0} en el centro ", oferta.NombreOferta);

                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;


        }

        public SearchOfertaUsadaResponse SearchOfertaUsada(int ofertaId)
        {
            var response = new SearchOfertaUsadaResponse();

            try
            {
                var candidaturaUsandoOferta = _candidaturaRepository.Find(x => x.IsActivo && x.CandidaturaOfertaId == ofertaId);
                if (candidaturaUsandoOferta == null)
                {
                    response.Usada = false;
                }
                else
                {
                    response.Usada = true;
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
        public GetOfertasByNombreResponse GetOfertasByNombre(string textSearch, int? centroId)
        {
            var response = new GetOfertasByNombreResponse() { IsValid = true };

            try
            {
                IQueryable<CandidaturaOferta> listaOfertas;

                if (centroId == null)
                {
                    listaOfertas = _candidaturaOfertaRepository.GetByCriteria(x => x.IsActivo);
                }
                else
                {
                    listaOfertas = _candidaturaOfertaRepository.GetByCriteria(x => x.IsActivo && x.CentroId == centroId);
                }
                
                response.Ofertas = listaOfertas.ConvertToOfertaViewModel().ToList();
                response.Ofertas = from oferta in response.Ofertas
                                              where oferta.NombreOferta.RemoveDiacritics().ToLower().Contains(textSearch.RemoveDiacritics().ToLower())
                                              select oferta;
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

        private IQueryable<CandidaturaOferta> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _candidaturaOfertaRepository.GetAll();

            // Solo devolvemos ofertas activas.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("NombreOferta") && (customFilter["NombreOferta"] != string.Empty))
            {
                    var nombreOferta = customFilter["NombreOferta"];
                    query = query.Where(x => x.NombreOferta.Contains(nombreOferta));
            }

            if (customFilter.ContainsKey("CentroId") && (customFilter["CentroId"] != string.Empty))
            {
                    var centroId = Convert.ToInt32(customFilter["CentroId"]);
                    query = query.Where(x => x.CentroId == centroId);
            }


            return query;
        }

        #endregion
    }
}
