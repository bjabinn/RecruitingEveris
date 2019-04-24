using Recruiting.Application.Proyectos.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Proyectos.Mappers
{
    public static class ProyectoMapper
    {
        #region Mappers

        public static ProyectoRowViewModel ConvertToProyectoRowViewModel(this Proyecto proyecto, Dictionary<int, string> nombresClientes)
        {
            var model = new ProyectoRowViewModel()
            {
                ProyectoId = proyecto.ProyectoId,
                Nombre = proyecto.Nombre,
                ClienteId = proyecto.ClienteId,
                CuentaCargo = proyecto.CuentaCargo,
                Persona = proyecto.Persona,
                CentroId = proyecto.CentroId ?? 0,
                Centro = proyecto.Centro.Nombre,
                SectorId = proyecto.SectorId,
                ServicioId = proyecto.ServicioId,
                Activo = proyecto.IsActivo
               
            };

            if ((nombresClientes != null) && nombresClientes.ContainsKey(model.ClienteId))
            {
                model.Cliente = nombresClientes[model.ClienteId];
            }

            return model;
        }

        public static ProyectoNombreIdViewModel ConvertToProyectoNombreIdViewModel(this Proyecto proyecto)
        {
            var model = new ProyectoNombreIdViewModel()
            {
                ProyectoId = proyecto.ProyectoId,
                Nombre = proyecto.Nombre
            };

            return model;
        }

        public static IEnumerable<ProyectoRowViewModel> ConvertToProyectoViewModel(this IEnumerable<Proyecto> proyectoList, Dictionary<int, string> nombresClientes)
        {
            var proyectoRowViewModelList = new List<ProyectoRowViewModel>();

            if (proyectoList == null)
            {
                return proyectoRowViewModelList;
            }

            proyectoRowViewModelList = proyectoList.Select(x => x.ConvertToProyectoRowViewModel(nombresClientes)).ToList();

            return proyectoRowViewModelList;
        }

        public static IEnumerable<ProyectoNombreIdViewModel> ConvertToProyectoNombreIdViewModel(this IEnumerable<Proyecto> proyectoList)
        {
            var proyectoNombreIdList = new List<ProyectoNombreIdViewModel>();

            if (proyectoList == null)
            {
                return proyectoNombreIdList;
            }

            proyectoNombreIdList = proyectoList.Select(x => x.ConvertToProyectoNombreIdViewModel()).ToList();

            return proyectoNombreIdList;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = name;

            switch (name)
            {
                case "Cliente":
                    attributeName = "Cliente.Nombre";
                    break;
            }

            return attributeName;
        }


        public static Proyecto Update(this Proyecto entity, ProyectoRowViewModel model)
        {
            if (entity == null)
            {
                entity = new Proyecto() { IsActivo = true };
            }

            entity.Nombre = model.Nombre;
            entity.ClienteId = model.ClienteId;
            entity.Persona = model.Persona;
            entity.CuentaCargo = model.CuentaCargo;
            entity.SectorId = model.SectorId;
            entity.ServicioId = model.ServicioId;
            entity.CentroId = model.CentroId;

            return entity;
        }

        #endregion

        #region Private Methods


        #endregion

    }
}
