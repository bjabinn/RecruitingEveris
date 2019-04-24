using Recruiting.Application.Permisos.Mappers;
using Recruiting.Application.Permisos.Messages;
using Recruiting.Business.BaseClasses.DataTable;
using Recruiting.Business.Entities;
using Recruiting.Business.Helpers;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Permisos.Services
{
    public class PermisoService : IPermisoService
    {
        #region Fields

        private readonly IPermisoRepository _permisoRepository;

        #endregion

        #region Constructors

        public PermisoService(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        #endregion

        #region IPermisoService Members

        public GetPermisosResponse GetPermisos(DataTableRequest request)
        {
            var response = new GetPermisosResponse();

            try
            {
                var query = FilterString(request.CustomFilters);
                var filtered = query.ApplyColumnSettings(request, PermisoMapper.GetPropertiePath);

                response.PermisoViewModel = filtered.ConvertToPermisosViewModel();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetPermisosResponse GetPermisos()
        {
            var response = new GetPermisosResponse();

            try
            {
                response.PermisoViewModel = PermisoMapper.ConvertToPermisosViewModel(_permisoRepository.GetByCriteria(x => x.IsActivo));
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
        private IQueryable<Permiso> FilterString(IDictionary<string, string> customFilter)
        {
            var query = _permisoRepository.GetAll();

            query = query.Where(x => x.IsActivo);

            if (customFilter.ContainsKey("Permiso") && (customFilter["Permiso"] != string.Empty))
            {
                    var permiso = customFilter["Permiso"];
                    query = query.Where(x => x.PermisoRol.Select(y => y.PermisoId.ToString()).Contains(permiso));
            }

            if (customFilter.ContainsKey("Nombre") && (customFilter["Nombre"] != string.Empty))
            {
                    var nombre = customFilter["Nombre"];
                    query = query.Where(x => x.Nombre.Contains(nombre));
            }

            return query;
        }
        #endregion
    }
}
