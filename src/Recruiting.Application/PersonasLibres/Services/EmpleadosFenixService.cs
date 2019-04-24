using Oracle.ManagedDataAccess.Client;
using Recruiting.Application.Helpers;
using Recruiting.Application.PersonasLibres.Mappers;
using Recruiting.Application.PersonasLibres.Messages;
using Recruiting.Application.PersonasLibres.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using Recruiting.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Recruiting.Application.PersonasLibres.Services
{
    public class EmpleadosFenixService : IEmpleadoFenixService
    {
        #region Fields

        private readonly IPersonaLibreRepository _personaLibreRepository;
        private readonly IFenixCategoriaLineaCeldaRepository _fenixCategoriaLineaCeldaRepository;
        private readonly string connectionString;
        #endregion

        #region Constructor
        public EmpleadosFenixService()
        {
            _personaLibreRepository = new PersonaLibreRepository();
            _fenixCategoriaLineaCeldaRepository = new FenixCategoriaLineaCeldaRepository();
            this.connectionString = ConfigurationManager.ConnectionStrings["Fenix"].ToString();
        }
        #endregion

        #region IEmpleadosFenixService members

        public GetEmpleadosFenixResponse GetEmpleadosFenix(DataTableRequest request, int centroId)
        {
            var response = new GetEmpleadosFenixResponse();

            try
            {
                if(request.CustomFilters.ContainsKey("Buscar"))
                {
                    var buscar = request.CustomFilters["Buscar"];
                    if(!string.IsNullOrEmpty(buscar))
                    {
                        var query = FilterString(request.CustomFilters, centroId);
                        var filtered = query.ApplyColumnSettings(request, EmpleadosFenixMapper.GetPropertiePath);

                        response.EmpleadoFenixRowViewModelList = filtered.ToList();
                        response.TotalElementos = query.Count();
                    }
                    else
                    {
                        response.EmpleadoFenixRowViewModelList = new List<EmpleadoFenixRowViewModel>();
                        response.TotalElementos = 0;
                    }


                    response.IsValid = true;
                }
              
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetListEmpleadosFenixCategoriaLineaCeldaResponse GetListEmpleadosFenixCategoriaLineaCelda(int centroId)
        {
            var response = new GetListEmpleadosFenixCategoriaLineaCeldaResponse();
            response.EmpleadosFenixListCategoriaLineaCeldaviewModel = new EmpleadosFenixListCategoriaLineaCeldaviewModel();
            response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListCategoria = new List<SelectListItem>();
            response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListLinea = new List<SelectListItem>();
            response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListCelda = new List<SelectListItem>();
            var listCategoriaEmpleadosFenix = new List<SelectListItem>();
            var listLineaEmpleadosFenix = new List<SelectListItem>();
            var listCeldaEmpleadosFenix = new List<SelectListItem>();
            try
            {
                var misCategoriaLineaCeldas = _fenixCategoriaLineaCeldaRepository.GetByCriteria(x => x.Usuario.CentroId == centroId);
                if (misCategoriaLineaCeldas != null)
                {
                    foreach (var categoriaLineaCelda in misCategoriaLineaCeldas)
                    {
                        if (categoriaLineaCelda.Tipo == "Categoria")
                        {
                            listCategoriaEmpleadosFenix.Add(new SelectListItem { Text = categoriaLineaCelda.Nombre, Value = categoriaLineaCelda.Nombre });
                        }
                        if (categoriaLineaCelda.Tipo == "Linea")
                        {
                            listLineaEmpleadosFenix.Add(new SelectListItem { Text = categoriaLineaCelda.Nombre, Value = categoriaLineaCelda.Nombre });
                        }
                        if (categoriaLineaCelda.Tipo == "Celda")
                        {
                            listCeldaEmpleadosFenix.Add(new SelectListItem { Text = categoriaLineaCelda.Nombre, Value = categoriaLineaCelda.Nombre });
                        }
                    }
                    response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListCategoria = listCategoriaEmpleadosFenix;
                    response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListLinea = listLineaEmpleadosFenix;
                    response.EmpleadosFenixListCategoriaLineaCeldaviewModel.ListCelda = listCeldaEmpleadosFenix;
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
        public UpdateCategoriaLineaCeldaInRecruitingDbResponse UpdateCategoriaLineaCeldaInRecruitingDb(int centroId)
        {
            var response = new UpdateCategoriaLineaCeldaInRecruitingDbResponse();
            try
            {
                var todasLosEmpleadosFenix = GetAllEmpleadosFenix(centroId).AsQueryable();
                if (todasLosEmpleadosFenix != null)
                {
                    var todasLasCategoriaLineaCeldas = _fenixCategoriaLineaCeldaRepository.GetByCriteria(x => x.Usuario.CentroId == centroId).ToList();
                    if (todasLasCategoriaLineaCeldas != null)
                    {
                        foreach (var categoriaLineaCelda in todasLasCategoriaLineaCeldas)
                        {
                            _fenixCategoriaLineaCeldaRepository.Delete(categoriaLineaCelda);
                        }
                    }

                    var listCategoria = todasLosEmpleadosFenix.Select(x => new { x.Categoria }).Distinct().ToArray();
                    var listLinea = todasLosEmpleadosFenix.Select(x => new { x.Linea }).Distinct().ToArray();
                    var listCelda = todasLosEmpleadosFenix.Select(x => new { x.Celda }).Distinct().ToArray();

                    int biggestList = Math.Max(listCategoria.Length, Math.Max(listLinea.Length, listCelda.Length));

                    for (int i = 0; i < biggestList; i++)
                    {
                        if (i < listCategoria.Length)
                        {
                            var categoria = new FenixCategoriaLineaCelda();
                            categoria.Nombre = listCategoria[i].Categoria;
                            categoria.Tipo = "Categoria";
                            categoria.Created = ModifiableEntityHelper.GetCurrentDate();
                            categoria.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                            _fenixCategoriaLineaCeldaRepository.Create(categoria);
                        }
                        if (i < listLinea.Length)
                        {
                            var linea = new FenixCategoriaLineaCelda();
                            linea.Nombre = listLinea[i].Linea;
                            linea.Tipo = "Linea";
                            linea.Created = ModifiableEntityHelper.GetCurrentDate();
                            linea.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                            _fenixCategoriaLineaCeldaRepository.Create(linea);
                        }
                        if (i < listCelda.Length)
                        {
                            var celda = new FenixCategoriaLineaCelda();
                            celda.Nombre = listCelda[i].Celda;
                            celda.Tipo = "Celda";
                            celda.Created = ModifiableEntityHelper.GetCurrentDate();
                            celda.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                            _fenixCategoriaLineaCeldaRepository.Create(celda);
                        }
                    }
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
        #region Private Methods
        private IQueryable<EmpleadoFenixRowViewModel> FilterString(IDictionary<string, string> customFilter, int centroId)
        {
            IQueryable<EmpleadoFenixRowViewModel> query = GetAllEmpleadosFenix(centroId).AsQueryable();

            if (customFilter.ContainsKey("Nombre") && (customFilter["Nombre"] != string.Empty))
            {
                    var nombre = customFilter["Nombre"].ToString().RemoveDiacritics().ToLower();                   
                    query = query.Where(x => x.Nombre.RemoveDiacritics().ToLower().Contains(nombre));                       
                    
            }

            if (customFilter.ContainsKey("Apellidos") && (customFilter["Apellidos"] != string.Empty))
            {
                var apellidos = customFilter["Apellidos"].ToString().RemoveDiacritics().ToLower();
                query = query.Where(x => x.Apellidos.RemoveDiacritics().ToLower().Contains(apellidos));
            }

            if (customFilter.ContainsKey("Categoria") && (customFilter["Categoria"] != string.Empty))
            {
                    var Categoria = customFilter["Categoria"];
                    query = query.Where(x => x.Categoria == Categoria);
            }

            if (customFilter.ContainsKey("NumeroEmpleado") && (customFilter["NumeroEmpleado"] != string.Empty))
            {
                    var NroEmpleado = Convert.ToInt32(customFilter["NumeroEmpleado"]);
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

            return query;
        }

        private void EliminarEmpleadoslibres(List<EmpleadoFenixRowViewModel> empleadosFenixFiltrados)
        {

            var personasLibresList = _personaLibreRepository.GetByCriteria(x => x.SinNecesidadAsignada && x.IsActivo).ToList();

            try
            {
                foreach (var personaLibre in personasLibresList)
                {
                    var empleadoFenixCoincidentes = empleadosFenixFiltrados.Where(x => x.NroEmpleado == personaLibre.NroEmpleado).ToList();
                    if (empleadoFenixCoincidentes != null)
                    {
                        foreach (var empleadoAEliminar in empleadoFenixCoincidentes)
                        {

                            empleadosFenixFiltrados.Remove(empleadoAEliminar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
        }

        private List<EmpleadoFenixRowViewModel> GetAllEmpleadosFenix(int centroId)
        {
            List<EmpleadoFenixRowViewModel> result = new List<EmpleadoFenixRowViewModel>();
            string query = "SELECT NRO_EMPLEADO, NOMBRE, APELLIDO, CATEGORIA, LINEA, CELDA, CENTRO FROM FENIX_REP.REPORT_IND_HEADCOUNT WHERE FECHA_BAJA IS NULL AND CELDA IS NOT NULL ORDER BY CELDA";
            try
            {
                //Aqui el acceso a la cadena de conexión.
                var connString = EmpleadosFenixMapper.ConvierteConnectionStringATuCentro(connectionString, centroId);
                using (var conn = new OracleConnection(connString))
                {
                    using (var command = new OracleCommand(query, conn))
                    {
                        conn.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader != null && reader.Read())
                            {
                                EmpleadoFenixRowViewModel EmployeeFenix = new EmpleadoFenixRowViewModel();
                                EmployeeFenix.NroEmpleado = reader.GetInt32(0);
                                EmployeeFenix.Nombre = reader.GetString(1);
                                EmployeeFenix.Apellidos = reader.GetString(2);
                                EmployeeFenix.Categoria = reader.GetString(3);
                                EmployeeFenix.Linea = reader.GetString(4);
                                EmployeeFenix.Celda = reader.GetString(5);
                                EmployeeFenix.Centro = reader.GetString(6);
                                result.Add(EmployeeFenix);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to data source Fenix" + ex.Message);
            }
            EliminarEmpleadoslibres(result);
            return result;
        }

        #endregion
    }
}
