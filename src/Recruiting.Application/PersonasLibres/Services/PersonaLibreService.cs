using Recruiting.Application.PersonasLibres.Mappers;
using Recruiting.Application.PersonasLibres.Messages;
using Recruiting.Application.PersonasLibres.ViewModels;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Recruiting.Data.EntityFramework.Repositories;

namespace Recruiting.Application.PersonasLibres.Services
{
    public class PersonaLibreService : IPersonasLibresService
    {
        #region Constants

        #endregion

        #region Fields

        private readonly IPersonaLibreRepository _PersonaLibreRepository;
        private readonly IPersonaLibreIdiomaRepository _PersonaLibreIdiomaRepository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public PersonaLibreService(IPersonaLibreRepository PersonaLibreRepository)
        {
            _PersonaLibreRepository = PersonaLibreRepository;
            _PersonaLibreIdiomaRepository = new PersonaLibreIdiomaRepository();
        }

        #endregion

        #region IPersonasLibreservice members

        public GetPersonasLibresResponse GetPersonasLibres(DataTableRequest request)
        {
            var response = new GetPersonasLibresResponse();

            try
            {

                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, PersonaLibreMapper.GetPropertiePath);

                response.PersonaLibreRowViewModel = filtered.ConvertToPersonaLibreRowViewModel();
                
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

        public GetPersonasLibresExportToExcelResponse GetPersonasLibresExportToExcel(DataTableRequest request)
        {
            var response = new GetPersonasLibresExportToExcelResponse();

            try
            {
                request.CustomFilters.Add("IsActivo", "true");
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, PersonaLibreMapper.GetPropertiePath);

                response.PersonaLibreRowExportToExcelViewModel = filtered.ConvertToPersonaLibreRowExportToExcelViewModel();
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


        public SearchPersonaLibreByNumeroEmpleadoResponse SearchPersonaLibreByNumeroEmpleado(string numeroEmpleado)
        {

            var response = new SearchPersonaLibreByNumeroEmpleadoResponse();

            var intNumEmpleado = Convert.ToInt32(numeroEmpleado);

            try
            {
                var PersonaLibre = _PersonaLibreRepository.GetOne(x => x.NroEmpleado == intNumEmpleado);
                if (PersonaLibre != null) //si no existe un PersonaLibre con ese numeroEmpleado 
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Ya existe un empleado con ese número empleado.";
                }

            }
            catch (Exception)
            {
                response.IsValid = true;
            }

            return response;
        }

        public GetPersonaLibreByIdResponse GetPersonaLibreById(int PersonaLibreId)
        {
            var response = new GetPersonaLibreByIdResponse();

            try
            {
                var PersonaLibre = _PersonaLibreRepository.GetOne(x => x.PersonaLibreId == PersonaLibreId);

                var createEditPersonaLibreViewModel = PersonaLibre.ConvertToCreateEditPersonaLibreViewModel();

                response.PersonaLibreViewModel = createEditPersonaLibreViewModel;

                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetPersonasLibresResponse GetPersonasLibresByCentroUsuarioId(int CentroUsuarioId)
        {
            var request = new DataTableRequest();

            request.CustomFilters = new Dictionary<string, string>();
            request.CustomFilters.Add("CentroUsuarioId", CentroUsuarioId.ToString());

            return GetPersonasLibres(request);

        }

        public SavePersonaLibreResponse SavePersonasLibres(PersonasLibresToCreateViewModel personasAGuardar)
        {
            var response = new SavePersonaLibreResponse();
            var personasLibresMapeadas = PersonaLibreMapper.ConvertToPersonasLibres(personasAGuardar);
            try
            {
                foreach (var persona in personasLibresMapeadas)
                {
                    _PersonaLibreRepository.Create(persona);
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

        public DeletePersonaLibreResponse DeletePersonaLibre(int PersonaLibreId)
        {
            var response = new DeletePersonaLibreResponse();

            try
            {
                var personaLibre = _PersonaLibreRepository.GetOne(x => x.PersonaLibreId == PersonaLibreId);

                //change active to delete
                personaLibre.IsActivo = false;

                bool seHaBorradoPersonaLibre = _PersonaLibreRepository.Update(personaLibre) > 0;

                if (seHaBorradoPersonaLibre)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                    response.ErrorMessage = "Error to delete Persona Libre";
                }

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public UpdatePersonaLibreByNecesidadIdAndPersonaLibreIdResponse UpdatePersonaLibreByNecesidadIdAndPersonaLibreId(int necesidadId, int personaLibreId)
        {
            var response = new UpdatePersonaLibreByNecesidadIdAndPersonaLibreIdResponse();
            try
            {

                var personaLibre = _PersonaLibreRepository.GetOne(x => (x.PersonaLibreId == personaLibreId) && (x.SinNecesidadAsignada) && (x.IsActivo));
                if (personaLibre != null)
                {
                    personaLibre.NecesidadId = necesidadId;
                    personaLibre.SinNecesidadAsignada = false;
                    _PersonaLibreRepository.Update(personaLibre);
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public LiberatePersonaLibreResponse LiberatePersonaLibre(int personaLibreId, int personaLibreNroEmpleado, int necesidadId)
        {
            var response = new LiberatePersonaLibreResponse();
            try
            {
                var posiblePersonaLibreSinNecesidadAsignada = _PersonaLibreRepository.GetOne(x => x.NroEmpleado == personaLibreNroEmpleado && x.SinNecesidadAsignada && x.IsActivo);
                var personaALiberar = _PersonaLibreRepository.GetOne(x => x.PersonaLibreId == personaLibreId
                                                                    && x.NecesidadId == necesidadId
                                                                    && !x.SinNecesidadAsignada && x.IsActivo);
                if (posiblePersonaLibreSinNecesidadAsignada != null)
                {
                    var personaABorrar = _PersonaLibreRepository.GetOne(x => x.NroEmpleado == personaLibreNroEmpleado
                                                                        && x.IsActivo && !x.SinNecesidadAsignada && x.NecesidadId == necesidadId);
                    personaABorrar.IsActivo = false;
                    _PersonaLibreRepository.Update(personaABorrar);
                    response.IsValid = true;
                }
                else
                {
                    if (personaALiberar != null)
                    {
                        personaALiberar.SinNecesidadAsignada = true;
                        personaALiberar.NecesidadId = null;
                        _PersonaLibreRepository.Update(personaALiberar);
                        response.IsValid = true;
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

        public GetListCategoriaLineaCeldaResponse GetListCategoriaLineaCelda()
        {
            var response = new GetListCategoriaLineaCeldaResponse();
            response.PersonasLibresListCategoriaLineaCeldaviewModel = new PersonasLibresListCategoriaLineaCeldaviewModel();
            response.PersonasLibresListCategoriaLineaCeldaviewModel.ListCategoria = new List<SelectListItem>();
            response.PersonasLibresListCategoriaLineaCeldaviewModel.ListLinea = new List<SelectListItem>();
            response.PersonasLibresListCategoriaLineaCeldaviewModel.ListCelda = new List<SelectListItem>();
            var listCategoriaPersonasLibres = new List<SelectListItem>();
            var listLineaPersonasLibres = new List<SelectListItem>();
            var listCeldaPersonasLibres = new List<SelectListItem>();
            try
            {
                var todasLasPersonasLibresActivas = _PersonaLibreRepository.GetByCriteria(x => x.IsActivo);
                if (todasLasPersonasLibresActivas != null)
                {
                    var listCategoria = todasLasPersonasLibresActivas.Select(x => new { x.Categoria }).Distinct().OrderBy(x => x.Categoria).ToArray();
                    var listLinea = todasLasPersonasLibresActivas.Select(x => new { x.Linea }).Distinct().OrderBy(x => x.Linea).ToArray();
                    var listCelda = todasLasPersonasLibresActivas.Select(x => new { x.Celda }).Distinct().OrderBy(x => x.Celda).ToArray();

                    int biggestList = Math.Max(listCategoria.Length, Math.Max(listLinea.Length, listCelda.Length));

                    for (int i = 0; i < biggestList; i++)
                    {
                        if (i < listCategoria.Length)
                        {
                            listCategoriaPersonasLibres.Add(new SelectListItem { Text = listCategoria[i].Categoria, Value = listCategoria[i].Categoria });
                        }
                        if (i < listLinea.Length)
                        {
                            listLineaPersonasLibres.Add(new SelectListItem { Text = listLinea[i].Linea, Value = listLinea[i].Linea });
                        }
                        if (i < listCelda.Length)
                        {
                            listCeldaPersonasLibres.Add(new SelectListItem { Text = listCelda[i].Celda, Value = listCelda[i].Celda });
                        }
                    }
                    response.PersonasLibresListCategoriaLineaCeldaviewModel.ListCategoria = listCategoriaPersonasLibres;
                    response.PersonasLibresListCategoriaLineaCeldaviewModel.ListLinea = listLineaPersonasLibres;
                    response.PersonasLibresListCategoriaLineaCeldaviewModel.ListCelda = listCeldaPersonasLibres;
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public UpdatePersonaLibreResponse UpdatePersonaLibre(CreateEditPersonaLibreViewModel createEditPersonaLibreViewModel)
        {
            var response = new UpdatePersonaLibreResponse();
            var personaLibre = _PersonaLibreRepository.GetOne(x => x.PersonaLibreId == createEditPersonaLibreViewModel.PersonaLibreId);
            var personaLibreIdioma = _PersonaLibreIdiomaRepository.GetOne(x => x.PersonaLibreId == createEditPersonaLibreViewModel.PersonaLibreId && x.IdiomaId == (int)TipoIdiomaEnum.Ingles);


            if (createEditPersonaLibreViewModel.NivelIdiomaId != null){
                if(personaLibreIdioma == null)
                {
                    personaLibre.LibreIdiomas.Add(
                        new PersonaLibreIdioma
                        {
                            PersonaLibreId = createEditPersonaLibreViewModel.PersonaLibreId.Value,
                            IdiomaId = (int)TipoIdiomaEnum.Ingles,
                            NivelIdiomaId = createEditPersonaLibreViewModel.NivelIdiomaId.Value,
                            IsActivo = true
                        }
                    );
                }else
                    personaLibre.LibreIdiomas.First().NivelIdiomaId = createEditPersonaLibreViewModel.NivelIdiomaId.Value;
            }
            else {
                if(personaLibreIdioma != null)
                    _PersonaLibreIdiomaRepository.Delete(personaLibreIdioma);
            }

            personaLibre.UpdatePersonaLibre(createEditPersonaLibreViewModel);
            var numPersonasLibresActualizados = _PersonaLibreRepository.Update(personaLibre);

       
            if (numPersonasLibresActualizados > 0)
            {
                response.IsValid = true;
            }
            else
            {
                response.IsValid = false;
                response.ErrorMessage = "Error to update Persona Libre";
            }

            return response;
        }

        #endregion

        #region Private Methods

        private IQueryable<PersonaLibre> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _PersonaLibreRepository.GetAll();

            if (customFilter.ContainsKey("Nombre") && (customFilter["Nombre"] != string.Empty))
            {
                    var nombre = customFilter["Nombre"];
                    query = query.Where(x => x.Nombre.Contains(nombre));
            }

            if (customFilter.ContainsKey("Apellidos") && (customFilter["Apellidos"] != string.Empty))
            {
                    var apellidos = customFilter["Apellidos"];
                    query = query.Where(x => x.Apellidos.Contains(apellidos));
            }

            if (customFilter.ContainsKey("Centro") && (customFilter["Centro"] != string.Empty))
            {
                    int centro = Convert.ToInt32(customFilter["Centro"]);
                    query = query.Where(x => x.Usuario.CentroId == centro);
            }

            if (customFilter.ContainsKey("Categoria") && (customFilter["Categoria"] != string.Empty))
            {
                    var Categoria = customFilter["Categoria"];
                    query = query.Where(x => x.Categoria == Categoria);
            }

            if (customFilter.ContainsKey("NroEmpleado") && (customFilter["NroEmpleado"] != string.Empty))
            {
                    var NroEmpleado = Convert.ToInt32(customFilter["NroEmpleado"]);
                    query = query.Where(x => x.NroEmpleado == NroEmpleado);
            }

            if (customFilter.ContainsKey("Linea") && (customFilter["Linea"] != string.Empty))
            {
                    var Linea = customFilter["Linea"];
                    query = query.Where(x => x.Linea == Linea);
            }

            if (customFilter.ContainsKey("Celda") && (customFilter["Celda"] != string.Empty))
            {
                    var Celda = customFilter["Celda"];
                    query = query.Where(x => x.Celda == Celda);
            }
            if (customFilter.ContainsKey("IsActivo") && (customFilter["IsActivo"] != string.Empty))
            {
                    var IsActivo = customFilter["IsActivo"];
                    if (IsActivo == "true")
                    {
                        query = query.Where(x => x.IsActivo);
                    }
                    else if (IsActivo == "false")
                    {
                        query = query.Where(x => !x.IsActivo);
                    }
            }

            if (customFilter.ContainsKey("SinNecesidadAsignada") && (customFilter["SinNecesidadAsignada"] != string.Empty))
            {
                    var value = customFilter["SinNecesidadAsignada"];
                    if (value == "true")
                    {
                        query = query.Where(x => x.SinNecesidadAsignada);
                    }
                    else if (value == "false")
                    {
                        query = query.Where(x => !x.SinNecesidadAsignada);
                    }
            }

            if (customFilter.ContainsKey("TipoTecnologiaId") && (customFilter["TipoTecnologiaId"] != string.Empty))
            {
                    var value = Convert.ToInt16(customFilter["TipoTecnologiaId"]);
                    query = query.Where(x => x.TipoTecnologiaId == value);
            }

            if (customFilter.ContainsKey("NivelIdioma") && customFilter["NivelIdioma"] != string.Empty)
            {
                var nivelIdiomaId = Convert.ToInt32(customFilter["NivelIdioma"]);
                query = query.Where(x => x.LibreIdiomas.Any(y => y.NivelIdiomaId >= nivelIdiomaId && y.IdiomaId == 15));
            }

            return query;
        }

        public SearchPersonaLibreByNombreYApellidosResponse SearchPersonaLibreByNombreYApellidos(string nombre, string apellidos)
        {
            var response = new SearchPersonaLibreByNombreYApellidosResponse();
            try
            {
                var PersonaLibre = _PersonaLibreRepository.GetOne(x => x.Nombre.Equals(nombre) && x.Apellidos.Equals(apellidos));

                if (PersonaLibre == null)
                {
                    response.IsValid = true;
                }
                else
                {
                    response.IsValid = false;
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
