using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Candidaturas.Enums;
using Recruiting.Application.Candidaturas.Messages;

using Recruiting.Application.Becarios.Messages;
using Recruiting.Application.Becarios.ViewModels;
using Recruiting.Application.Becarios.Mappers;


using Recruiting.Application.Helpers;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Recruiting.Infra.Helpers;
using Recruiting.Data.EntityFramework.Repositories;

namespace Recruiting.Application.Becarios.Services
{
    public class BecarioCentroService: IBecarioCentroService 
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IBecarioCentroRepository _becarioCentroRepository;        
        private readonly IBecarioRepository _becarioRepository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BecarioCentroService(IBecarioCentroRepository becarioCentroRepository)
        {
            _becarioCentroRepository = becarioCentroRepository;
            _becarioRepository = new BecarioRepository();
            
            
        }

        #endregion

        #region ICandidatoService members

        public GetCentrosByNombreCentroResponse GetCentrosByNombreCentro(string textSearch)
        {
            var response = new GetCentrosByNombreCentroResponse() { IsValid = true };

            try
            {
                var listaCentros = _becarioCentroRepository.GetByCriteria(x => x.IsActivo);
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
        public GetCentrosResponse GetCentros(DataTableRequest request)
        {
            var response = new GetCentrosResponse();

            try
            {               
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, BecarioCentroMapper.GetPropertiePath);                 

                response.CentroRowViewModel = filtered.ConvertToCentroViewModel();
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
                var centro = _becarioCentroRepository.GetOne(x => x.Centro.ToLower().Equals(nombre)
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
                var becarioUsandoCentro = _becarioRepository.Find(x => x.IsActivo && x.BecarioCentroProcedenciaId == centroId);
                if (becarioUsandoCentro == null)
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

        private IQueryable<BecarioCentroProcedencia> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _becarioCentroRepository.GetAll();

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
                var centroGuardar = _becarioCentroRepository.GetOne(x => x.BecarioCentroProcedenciaId == idCentro && x.IsActivo);

                if(centroGuardar == null)
                {
                    BecarioCentroProcedencia nuevoCentro = new BecarioCentroProcedencia()
                    {
                        Centro = centro,
                        Ciudad = ciudad,
                        Pais = pais,
                        IsActivo = true
                    };

                    _becarioCentroRepository.Create(nuevoCentro);
                }
                else
                {
                    centroGuardar.Centro = centro;
                    centroGuardar.Ciudad = ciudad;
                    centroGuardar.Pais = pais;
                    _becarioCentroRepository.Update(centroGuardar);
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
                var centroEditar = _becarioCentroRepository.GetOne(x => x.BecarioCentroProcedenciaId == centroId);
                centroEditar.Centro = centro;
                centroEditar.Ciudad = ciudad;
                centroEditar.Pais = pais;
                _becarioCentroRepository.Update(centroEditar);
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
                var centroBorrar = _becarioCentroRepository.GetOne(x => x.BecarioCentroProcedenciaId == centroId);
                //cambiamos el activo a =0(borrado lógico)
                centroBorrar.IsActivo = false;
                if (_becarioCentroRepository.Update(centroBorrar) > 0)
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
