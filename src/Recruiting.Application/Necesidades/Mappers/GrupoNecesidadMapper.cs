using Recruiting.Application.Helpers;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Necesidades.ViewModel;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Necesidades.Mappers
{
    public static class GrupoNecesidadMapper
    {
        #region Mapper

        public static void UpdateGrupoNecesidad(this GrupoNecesidad grupoNecesidad, CreateEditSoloGrupoNecesidadViewModel grupoNecesidadVM)
        {
            if (grupoNecesidadVM.GrupoNecesidadId.HasValue)
            {
                grupoNecesidad.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                grupoNecesidad.Modified = ModifiableEntityHelper.GetCurrentDate();
                grupoNecesidad.GrupoNecesidadId = grupoNecesidadVM.GrupoNecesidadId.Value;
            }
            else
            {
                grupoNecesidad.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                grupoNecesidad.Created = ModifiableEntityHelper.GetCurrentDate();
            }
            grupoNecesidad.Nombre = grupoNecesidadVM.NombreGrupo;
            grupoNecesidad.Descripcion = grupoNecesidadVM.DescripcionGrupo;
            grupoNecesidad.GrupoCerrado = grupoNecesidadVM.EstadoGrupo;
            grupoNecesidad.IsActivo = true;
        }
        public static string GetPropertiePath(string name)
        {
            string attributeName = name;

            switch (name)
            {
                case "GrupoNecesidadId":
                    attributeName = "GrupoNecesidadId";
                    break;
                case "NombreGrupoNecesidad":
                    attributeName = "NombreGrupoNecesidad";
                    break;              
                case "EstadoGrupoNecesidad":
                    attributeName = "EstadoGrupoNecesidad";
                    break;
                case "Cliente":
                    attributeName = "Cliente";
                    break;
                case "Proyecto":
                    attributeName = "Proyecto";
                    break;
                case "Centro":
                    attributeName = "Centro";
                    break;
            }
            return attributeName;
        }

        public static IEnumerable<GrupoNecesidadesRowViewModel> ConvertToGrupoNecesidadRowViewModel(this IEnumerable<GrupoNecesidad> grupoList)
        {
            var GrupoRowViewModel = new List<GrupoNecesidadesRowViewModel>();

            if (grupoList == null) return GrupoRowViewModel;

            GrupoRowViewModel = grupoList.Select(x => x.ConvertToGrupoNecesidadRowViewModel()).ToList();

            return GrupoRowViewModel;
        }

        private static GrupoNecesidadesRowViewModel ConvertToGrupoNecesidadRowViewModel(this GrupoNecesidad grupoNecesidad)
        {
            GrupoNecesidadesRowViewModel grupoNecesidadRowViewModel = new GrupoNecesidadesRowViewModel();
            var numeroNecesidadesAsignadas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId != (int)EstadoNecesidadEnum.Cancelado);
            var numeroNecesidadesAbiertas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta);
            var numeroNecesidadesPreasiganas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada);
            var numeroNecesidadesCerradas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada);
            grupoNecesidadRowViewModel.GrupoNecesidadId = grupoNecesidad.GrupoNecesidadId;
            grupoNecesidadRowViewModel.NombreGrupo = grupoNecesidad.Nombre;
            grupoNecesidadRowViewModel.NecesidadesAsignadas = numeroNecesidadesAsignadas;
            grupoNecesidadRowViewModel.NecesidadesAbiertas = numeroNecesidadesAbiertas;
            grupoNecesidadRowViewModel.NecesidadesPreasignadas = numeroNecesidadesPreasiganas;
            grupoNecesidadRowViewModel.NecesidadesCerradas = numeroNecesidadesCerradas;

            if (grupoNecesidad.GrupoCerrado)
            {
                grupoNecesidadRowViewModel.EstadoGrupo = "Cerrado";
            }
            else
            {
                grupoNecesidadRowViewModel.EstadoGrupo = "Abierto";
            }
            if (numeroNecesidadesAsignadas > 0)
            {
                grupoNecesidadRowViewModel.NombreCliente = grupoNecesidad.NecesidadesAsignadas.FirstOrDefault().Proyecto.Cliente.Nombre;
                grupoNecesidadRowViewModel.NombreProyecto = grupoNecesidad.NecesidadesAsignadas.FirstOrDefault().Proyecto.Nombre;
            }

            return grupoNecesidadRowViewModel;

        }

        public static IEnumerable<NecesidadGrupoRowExportToExcelViewModel> ConvertToNecesidadGrupoRowExportToExcelViewModel(this IEnumerable<GrupoNecesidad> NecesidadGrupoList)
        {
            var NecesidadGrupoRowExportToExcelViewModelList = new List<NecesidadGrupoRowExportToExcelViewModel>();

            if (NecesidadGrupoList == null) return NecesidadGrupoRowExportToExcelViewModelList;

            NecesidadGrupoRowExportToExcelViewModelList = NecesidadGrupoList.Select(x => x.ConvertToNecesidadGrupoRowExportToExcelViewModel()).ToList();

            return NecesidadGrupoRowExportToExcelViewModelList;
        }
        public static NecesidadGrupoRowExportToExcelViewModel ConvertToNecesidadGrupoRowExportToExcelViewModel(this GrupoNecesidad grupoNecesidad)
        {
            var necesidadGrupoRowExportToExcelViewModel = new NecesidadGrupoRowExportToExcelViewModel
            {
                Referencia = grupoNecesidad.GrupoNecesidadId,
                Nombre = grupoNecesidad.Nombre,
                Cliente = grupoNecesidad.NecesidadesAsignadas.FirstOrDefault().Proyecto.Cliente.Nombre,
                Proyecto = grupoNecesidad.NecesidadesAsignadas.FirstOrDefault().Proyecto.Nombre,
                NumNecesidades = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId != (int)EstadoNecesidadEnum.Cancelado),
                NumNecesidadesAbiertas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Abierta),
                NumNecesidadesPreasignadas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Preasignada),
                NumNecesidadesCerradas = grupoNecesidad.NecesidadesAsignadas.Count(x => x.IsActivo && x.EstadoNecesidadId == (int)EstadoNecesidadEnum.Cerrada),
                Estado = grupoNecesidad.IsActivo.ToString()

            };
            if (!grupoNecesidad.GrupoCerrado)
            {
                necesidadGrupoRowExportToExcelViewModel.Estado = "Abierto";
            }
            else
            {
                necesidadGrupoRowExportToExcelViewModel.Estado = "Cerrado";
            }


            return necesidadGrupoRowExportToExcelViewModel;
        }

        #endregion
    }
}
