using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Necesidades.Mappers;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Necesidades.Services
{
    public class GrupoNecesidadService : IGrupoNecesidadService
    {
        #region Fields

        private readonly IGrupoNecesidadRepository _grupoNecesidadRepository;
        private readonly INecesidadRepository _necesidadRepository;
        private readonly INecesidadService _necesidadService;

        #endregion


        #region Constructors

        public GrupoNecesidadService(IGrupoNecesidadRepository grupoNecesidadRepository, INecesidadRepository necesidadRepository)
        {
            _grupoNecesidadRepository = grupoNecesidadRepository;
            _necesidadRepository = necesidadRepository;
            _necesidadService = new NecesidadService(necesidadRepository);
        }

        #endregion

        

        public SaveGrupoNecesidadResponse SaveGrupoNecesidad(CreateEditSoloGrupoNecesidadViewModel viewModel, int? centro)
        {
            var response = new SaveGrupoNecesidadResponse();
            GrupoNecesidad grupo = new GrupoNecesidad();
            try
            {
                if (viewModel.GrupoNecesidadId == null)
                {
                    grupo.UpdateGrupoNecesidad(viewModel);
                    _grupoNecesidadRepository.Create(grupo);
                }
                else
                {
                    var grupoActual = _grupoNecesidadRepository.GetOne(x => x.GrupoNecesidadId == viewModel.GrupoNecesidadId.Value);
                    grupoActual.UpdateGrupoNecesidad(viewModel);
                    _grupoNecesidadRepository.Update(grupoActual);
                }

                response.GrupoNecesidadId = _grupoNecesidadRepository.GetOne(x => x.Nombre == viewModel.NombreGrupo
                    && x.IsActivo && !x.GrupoCerrado && (!(x.Usuario.CentroId.HasValue) || x.Usuario.CentroId == centro.Value)).GrupoNecesidadId;
                response.IsValid = true;
           
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsValid = false;
            }
            return response;
        }
        public GetGrupoNecesidadByIdResponse GetGrupoNecesidadById(int grupoId)
        {
            var response = new GetGrupoNecesidadByIdResponse();
            try
            {
                var grupoNecesidades = _grupoNecesidadRepository.GetOne(x => x.GrupoNecesidadId == grupoId && x.IsActivo);
                var necesidadesDelGrupo = _necesidadRepository.GetByCriteria(x => x.GrupoNecesidadId == grupoId && x.IsActivo);
                response.GrupoNecesidadViewModel = NecesidadMapper.ConvertToCreateEditGrupoNecesidadViewModel(grupoNecesidades, necesidadesDelGrupo);
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsValid = false;
            }
            return response;
        }

        public CheckGrupoCerradoResponse CheckGrupoCerrado(int grupoId)
        {
            var response = new CheckGrupoCerradoResponse();
            try
            {
                response.IsValid = false;
                var grupo = _grupoNecesidadRepository.GetOne(x => x.GrupoNecesidadId == grupoId);
                if ((!grupo.NecesidadesAsignadas.Any(x => x.EstadoNecesidadId != (int)EstadoNecesidadEnum.Cerrada &&
                                                   x.EstadoNecesidadId != (int)EstadoNecesidadEnum.Cancelado &&
                                                   x.IsActivo)) && 
                                                   (grupo.NecesidadesAsignadas.Any(x => x.IsActivo)))
                {
                    grupo.GrupoCerrado = true;
                }
                else
                {
                    if (grupo.GrupoCerrado)
                    {
                        grupo.GrupoCerrado = false;
                    }
                }
                if (_grupoNecesidadRepository.Update(grupo) > 0)
                {
                    response.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsValid = false;
            }
            return response;
        }

        public GetGruposNecesidadesResponse GetGruposNecesidades(DataTableRequest request)
        {
            var response = new GetGruposNecesidadesResponse();

            try
            {
               
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, GrupoNecesidadMapper.GetPropertiePath);

                response.GrupoNecesidadesRowViewModel = filtered.ConvertToGrupoNecesidadRowViewModel();         
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

        public SearchGrupoNecesidadByNombreResponse SearchGrupoNecesidadByNombre(string nombreGrupo)
        {
            var response = new SearchGrupoNecesidadByNombreResponse();

            try
            {
                var grupo = _grupoNecesidadRepository.GetOne(x => x.Nombre.Equals(nombreGrupo) && x.IsActivo);

                if (grupo == null)
                {
                    response.IsValid = true;
                }
                else if (grupo.IsActivo && !grupo.GrupoCerrado)
                {
                    response.IsValid = false;
                    response.ErrorMessage = string.Format("Ya existe algún grupo con el nombre: {0}.", nombreGrupo);

                }
                else if (grupo.IsActivo && grupo.GrupoCerrado)
                {
                    response.IsValid = true;
                }
                else if (!grupo.IsActivo)
                {
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


        public DeleteGrupoNecesidadResponse DeleteGrupoNecesidad(int grupoId)
        {
            var response = new DeleteGrupoNecesidadResponse();

            try
            {
                var grupoNecesidad = _grupoNecesidadRepository.GetOne(x => x.GrupoNecesidadId == grupoId);
                foreach(var necesidad in grupoNecesidad.NecesidadesAsignadas)
                {
                    _necesidadService.DeleteNecesidad(necesidad.NecesidadId, false);
                }
                //change active to delete
                grupoNecesidad.IsActivo = false;
                _grupoNecesidadRepository.Update(grupoNecesidad);                 
                response.IsValid = true;           

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        public GetNecesidadesGrupoExportToExcellResponse GetNecesidadesGrupoExportToExcel(DataTableRequest request)
        {
            var response = new GetNecesidadesGrupoExportToExcellResponse();

            try
            {
                //establecer los filtros
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, GrupoNecesidadMapper.GetPropertiePath);

                response.NecesidadGrupoExportToExcellViewModel = filtered.ConvertToNecesidadGrupoRowExportToExcelViewModel();
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

        private IQueryable<GrupoNecesidad> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _grupoNecesidadRepository.GetAll();

            // Solo devolvemos grupos activos.
            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("GrupoNecesidadId") && (customFilter["GrupoNecesidadId"] != string.Empty))
            {
                    var grupoNecesidadId = Convert.ToInt32(customFilter["GrupoNecesidadId"]);
                    query = query.Where(x => x.GrupoNecesidadId == grupoNecesidadId);
            }

            if (customFilter.ContainsKey("NombreGrupoNecesidad") && (customFilter["NombreGrupoNecesidad"] != string.Empty))
            {
                    var nombreGrupoNecesidad = Convert.ToString(customFilter["NombreGrupoNecesidad"]);
                    query = query.Where(x => x.Nombre.Contains(nombreGrupoNecesidad));
            }
            if (customFilter.ContainsKey("EstadoGrupoNecesidad") && (customFilter["EstadoGrupoNecesidad"] != string.Empty))
            {
                    var estadoGrupoNecesidad = Convert.ToBoolean(customFilter["EstadoGrupoNecesidad"]);
                    query = query.Where(x => x.GrupoCerrado == estadoGrupoNecesidad);
            }
            if (customFilter.ContainsKey("Cliente") && (customFilter["Cliente"] != string.Empty))
            {
                    var cliente = Convert.ToInt32(customFilter["Cliente"]);
                    query = query.Where(x => x.NecesidadesAsignadas.Any(y => y.Proyecto.ClienteId == cliente));
            }
            if (customFilter.ContainsKey("Proyecto") && (customFilter["Proyecto"] != string.Empty))
            {
                    var proyecto = Convert.ToInt32(customFilter["Proyecto"]);
                    query = query.Where(x => x.NecesidadesAsignadas.Any(y => y.ProyectoId == proyecto));
            }
            if (customFilter.ContainsKey("Centro") && (customFilter["Centro"] != string.Empty))
            {
                var centro = Convert.ToInt32(customFilter["Centro"]);
                query = query.Where(x => x.Usuario.CentroId == centro);
            }
            if (customFilter.ContainsKey("CentroUsuarioId") && (customFilter["CentroUsuarioId"] != string.Empty))
            {
                    var centro = Convert.ToInt32(customFilter["CentroUsuarioId"]);
                    query = query.Where(x => x.Usuario.CentroId == centro);
            }
            return query;
        }
    }
}
