using Recruiting.Application.Candidatos.Mappers;
using Recruiting.Application.Candidatos.Messages;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Candidatos.Services
{
    public class CandidatoCentroService: ICandidatoCentroService
    {
        #region Constants

        #endregion

        #region Fields

    
        private readonly ICandidatoCentroEducativoRepository _candidatoCentroRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IBecarioRepository _becarioRepository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CandidatoCentroService(ICandidatoCentroEducativoRepository candidatoCentroRepository)
        {
            _candidatoCentroRepository = candidatoCentroRepository;
            _becarioRepository = new BecarioRepository();
            _candidatoRepository = new CandidatoRepository();
            
            
        }

        #endregion

        #region ICandidatoService members

        public GetCentrosByNombreCentroEducativoResponse GetCentrosByNombreCentro(string textSearch)
        {
            var response = new GetCentrosByNombreCentroEducativoResponse() { IsValid = true };

            try
            {
                var listaCentros = _candidatoCentroRepository.GetByCriteria(x => x.IsActivo);
                response.CentrosProcedencia = listaCentros.ConvertToCentroViewModel().ToList();
                response.CentrosProcedencia = from centro in response.CentrosProcedencia
                                              where centro.Centro.RemoveDiacritics().ToLower().Contains(textSearch.RemoveDiacritics().ToLower())
                                    select centro;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public GetCentrosEducativosResponse GetCentros(DataTableRequest request)
        {
            var response = new GetCentrosEducativosResponse();

            try
            {               
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, CandidatoCentroMapper.GetPropertiePath);                 

                response.CentroEducativo = filtered.ConvertToCentroViewModel();
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

        public SearchCentroByNombreCiudadPaisResponse SearchCentroByNombreCiudadPais(string nombre, string ciudad, string pais)
        {
            var response = new SearchCentroByNombreCiudadPaisResponse();

            try
            {
                nombre = nombre.RemoveDiacritics().ToLower();
                ciudad = ciudad.RemoveDiacritics().ToLower();
                if (pais.Contains('ñ'))
                {
                    pais = pais.ToLower();
                }
                else
                {
                    pais = pais.RemoveDiacritics().ToLower();
                }
                var centro = _candidatoCentroRepository.GetOne(x => x.Centro.ToLower().Equals(nombre)
                                                            && x.Ciudad.ToLower().Equals(ciudad)
                                                            && x.Pais.ToLower().Equals(pais)
                                                            && x.IsActivo);

                if (centro == null || !centro.IsActivo)
                {
                    response.IsValid = true;
                }
                else if (centro.IsActivo)
                {
                    response.IsValid = false;
                    response.ErrorMessage = string.Format("Ya existe algún centro con el nombre: {0} en la ciudad {1} y país {2}.", centro.Centro, centro.Ciudad, centro.Pais);

                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;


        }

        public SearchCentroUsadoResponse SearchCentroUsado(int centroId)
        {
            var response = new SearchCentroUsadoResponse();

            try
            {
                var candidatoUsandoCentro = _candidatoRepository.Find(x => x.IsActivo && x.CandidatoCentroEducativoId == centroId);
                if (candidatoUsandoCentro == null)
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
       

        #endregion

        #region Private Methods

        private IQueryable<CandidatoCentroEducativo> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _candidatoCentroRepository.GetAll();

            // Solo devolvemos centros activos.
            query = query.Where(x => x.IsActivo);
           
            if (customFilter.ContainsKey("Centro") && (customFilter["Centro"] != string.Empty))
            {
                    var centro = customFilter["Centro"];                    
                    query = query.Where(x => x.Centro.Contains(centro));
            }

            if (customFilter.ContainsKey("Ciudad") && (customFilter["Ciudad"] != string.Empty))
            {
                    var ciudad = customFilter["Ciudad"];
                    query = query.Where(x => x.Ciudad.Contains(ciudad));
            }
            if (customFilter.ContainsKey("Pais") && (customFilter["Pais"] != string.Empty))
            {
                    var pais = customFilter["Pais"];
                    query = query.Where(x => x.Pais.Contains(pais));
            }

            return query;
        }

        public SaveCentroResponse SaveCentro(int idCentro, string centro, string ciudad, string pais)
        {
            var response = new SaveCentroResponse();

            try
            {
                var centroGuardar = _candidatoCentroRepository.GetOne(x => x.CandidatoCentroEducativoId == idCentro && x.IsActivo);

                if(centroGuardar == null)
                {
                    CandidatoCentroEducativo nuevoCentro = new CandidatoCentroEducativo()
                    {
                        Centro = centro,
                        Ciudad = ciudad,
                        Pais = pais,
                        IsActivo = true
                    };

                    _candidatoCentroRepository.Create(nuevoCentro);
                }
                else
                {
                    centroGuardar.Centro = centro;
                    centroGuardar.Ciudad = ciudad;
                    centroGuardar.Pais = pais;
                    _candidatoCentroRepository.Update(centroGuardar);
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

        public EditCentroResponse EditCentro(int centroId, string centro, string ciudad, string pais)
        {
            var response = new EditCentroResponse();

            try
            {
                var centroEditar = _candidatoCentroRepository.GetOne(x => x.CandidatoCentroEducativoId == centroId);
                centroEditar.Centro = centro;
                centroEditar.Ciudad = ciudad;
                centroEditar.Pais = pais;
                _candidatoCentroRepository.Update(centroEditar);
                response.IsValid = true;

            }
            catch (Exception ex)
            {

                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public RemoveCentroResponse RemoveCentro(int centroId)
        {
            var response = new RemoveCentroResponse();
            try
            {
                var centroBorrar = _candidatoCentroRepository.GetOne(x => x.CandidatoCentroEducativoId == centroId);
                //cambiamos el activo a =0(borrado lógico)
                centroBorrar.IsActivo = false;
                if (_candidatoCentroRepository.Update(centroBorrar) > 0)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error deleting Centro";
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
    }
}
