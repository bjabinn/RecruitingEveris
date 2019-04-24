
using Recruiting.Application.Becarios.Mappers;
using Recruiting.Application.Becarios.Messages;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Becarios.Services
{
    public class BecarioConvocatoriaService: IBecarioConvocatoriaService 
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IBecarioConvocatoriaRepository _becarioConvocatoriaRepository;  
        private readonly IBecarioRepository _becarioRepository; 

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BecarioConvocatoriaService(IBecarioConvocatoriaRepository becarioConvocatoriaRepository)
        {
            _becarioConvocatoriaRepository = becarioConvocatoriaRepository;
            _becarioRepository = new BecarioRepository();
        }

        #endregion

        #region PublicMethods


        public SaveConvocatoriaResponse SaveConvocatoria(int idConvocatoria, string nombreConvocatoria, int centroId)
        {
            var response = new SaveConvocatoriaResponse();

            try
            {

                var convocatoria = _becarioConvocatoriaRepository.GetOne(x => x.BecarioConvocatoriaId == idConvocatoria && x.IsActivo);

                if(convocatoria == null)
                {
                    BecarioConvocatoria nuevaConvocatoria = new BecarioConvocatoria()
                    {
                        NombreConvocatoria = nombreConvocatoria,
                        CentroId = centroId,
                        IsActivo = true
                    };

                    _becarioConvocatoriaRepository.Create(nuevaConvocatoria);
                }
                else
                {
                    convocatoria.NombreConvocatoria = nombreConvocatoria;
                    convocatoria.CentroId = centroId;
                    _becarioConvocatoriaRepository.Update(convocatoria);

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

        public GetConvocatoriasResponse GetConvocatorias(DataTableRequest request)
        {
            var response = new GetConvocatoriasResponse();

            try
            {               
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BecarioConvocatoriaMapper.GetPropertiePath);

                response.ConvocatoriaRowViewModel = filtered.ConvertToConvocatoriaViewModel();
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

        public RemoveConvocatoriaResponse RemoveConvocatoria(int convocatoriaId)
        {
            var response = new RemoveConvocatoriaResponse();
            try
            {
                var convocatoriaBorrar = _becarioConvocatoriaRepository.GetOne(x => x.BecarioConvocatoriaId == convocatoriaId);
                //cambiamos el activo a =0(borrado lógico)
                convocatoriaBorrar.IsActivo = false;
                if (_becarioConvocatoriaRepository.Update(convocatoriaBorrar) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error deleting Convocatoria";
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SearchConvocatoriaByNombreCentroIdResponse SearchConvocatoriaByNombreCentroId(string nombreConvocatoria, int centroId)
        {
            var response = new SearchConvocatoriaByNombreCentroIdResponse();

            try
            {
                nombreConvocatoria = nombreConvocatoria.RemoveDiacritics().ToLower();
               
                var convocatoria = _becarioConvocatoriaRepository.GetOne(x => x.NombreConvocatoria.ToLower().Equals(nombreConvocatoria)
                                                            && x.CentroId == centroId
                                                            && x.IsActivo);

                if (convocatoria == null || !convocatoria.IsActivo)
                {
                    response.IsValid = true;
                }
                else if (convocatoria.IsActivo)
                {
                    response.IsValid = false;
                    response.ErrorMessage = string.Format("Ya existe alguna convocatoria con el nombre: {0} en el centro ", convocatoria.NombreConvocatoria);

                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;


        }

        public SearchConvocatoriaUsadaResponse SearchConvocatoriaUsada(int convocatoriaId)
        {
            var response = new SearchConvocatoriaUsadaResponse();

            try
            {
                var becarioUsandoCentro = _becarioRepository.Find(x => x.IsActivo && x.BecarioConvocatoriaId == convocatoriaId);
                if (becarioUsandoCentro == null)
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
        public GetConvocatoriasByNombreResponse GetConvocatoriasByNombre(string textSearch, int? centroId)
        {
            var response = new GetConvocatoriasByNombreResponse() { IsValid = true };

            try
            {
                IQueryable<BecarioConvocatoria> listaConvocatorias;

                if (centroId == null)
                {
                    listaConvocatorias = _becarioConvocatoriaRepository.GetByCriteria(x => x.IsActivo);
                }
                else
                {
                    listaConvocatorias = _becarioConvocatoriaRepository.GetByCriteria(x => x.IsActivo && x.CentroId == centroId);
                }
                
                response.Convocatorias = listaConvocatorias.ConvertToConvocatoriaViewModel().ToList();
                response.Convocatorias = from convocatoria in response.Convocatorias
                                              where convocatoria.NombreConvocatoria.RemoveDiacritics().ToLower().Contains(textSearch.RemoveDiacritics().ToLower())
                                              select convocatoria;
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

        private IQueryable<BecarioConvocatoria> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _becarioConvocatoriaRepository.GetAll();

            // Solo devolvemos convocatorias activas.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("NombreConvocatoria") && (customFilter["NombreConvocatoria"] != string.Empty))
            {
                    var nombreConvocatoria = customFilter["NombreConvocatoria"];
                    query = query.Where(x => x.NombreConvocatoria.Contains(nombreConvocatoria));
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
