using Recruiting.Application.Helpers;
using Recruiting.Application.Ofertas.ViewModels;
using Recruiting.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recruiting.Application.Ofertas.Mappers
{
    public static class OfertaMapper
    {
        #region Mapper
        public static CreateEditOfertaViewModel ConvertToCreateEditOfertaViewModel(this Oferta oferta)
        {
            var createEditOfertaViewModel = new CreateEditOfertaViewModel()
            {
                OfertaId = oferta.OfertaId,
                Nombre = oferta.Nombre,
                Descripcion = oferta.Descripcion,
                FechaPublicacion = oferta.FechaPublicacion,
                EstadoOfertaId = oferta.EstadoOfertaId,
                Activo = oferta.IsActivo
            };

            return createEditOfertaViewModel;
        }

        public static OfertaNombreIdViewModel ConvertToOfertaNombreIdViewModel(this Oferta oferta)
        {
            var OfertaNombreIdViewModel = new OfertaNombreIdViewModel()
            {
                OfertaId = oferta.OfertaId,
                Nombre = oferta.Nombre
            };

            return OfertaNombreIdViewModel;
        }

        public static void UpdateOferta(this Oferta oferta, CreateEditOfertaViewModel createEditOfertaViewModel)
        {
            if(createEditOfertaViewModel.OfertaId != null)
            {
                oferta.OfertaId =(int) createEditOfertaViewModel.OfertaId;

                oferta.ModifiedBy = ModifiableEntityHelper.GetCurrentUser();
                oferta.Modified = ModifiableEntityHelper.GetCurrentDate();
            }
            else
            {
                oferta.CreatedBy = ModifiableEntityHelper.GetCurrentUser();
                oferta.Created = ModifiableEntityHelper.GetCurrentDate();
            }

            oferta.Nombre = createEditOfertaViewModel.Nombre;
            oferta.EstadoOfertaId = createEditOfertaViewModel.EstadoOfertaId;
            oferta.FechaPublicacion = (DateTime)createEditOfertaViewModel.FechaPublicacion;
            oferta.Descripcion = createEditOfertaViewModel.Descripcion;
            oferta.IsActivo = true;            
        }

        public static IEnumerable<OfertaNombreIdViewModel> ConvertToOfertaNombreIdViewModel(this IEnumerable<Oferta> ofertaList)
        {
            var OfertaNombreIdViewModel = new List<OfertaNombreIdViewModel>();

            if (ofertaList == null) return OfertaNombreIdViewModel;

            OfertaNombreIdViewModel = ofertaList.Select(x => x.ConvertToOfertaNombreIdViewModel()).ToList();

            return OfertaNombreIdViewModel;
        }

        public static IEnumerable<OfertaRowViewModel> ConvertToOfertaRowViewModel(this IEnumerable<Oferta> ofertaList, Dictionary<int, int> totalCandidatos)
        {
            var ofertaRowViewModelList = new List<OfertaRowViewModel>();

            if (ofertaList == null) return ofertaRowViewModelList;

            ofertaRowViewModelList = ofertaList.Select(x => x.ConvertToOfertaRowViewModel(totalCandidatos)).ToList();

            return ofertaRowViewModelList;
        }

        public static IEnumerable<OfertaRowViewModel> ConvertToOfertaRowViewModelSinCandidatos(this IEnumerable<Oferta> ofertaList)
        {
            var ofertaRowViewModelList = new List<OfertaRowViewModel>();

            if (ofertaList == null) return ofertaRowViewModelList;

            ofertaRowViewModelList = ofertaList.Select(x => x.ConvertToOfertaRowViewModelSinCandidatos()).ToList();

            return ofertaRowViewModelList;
        }

        public static IEnumerable<OfertaRowExportToExcelViewModel> ConvertToOfertaRowExportToExcelViewModel(this IEnumerable<Oferta> ofertaList, Dictionary<int, int> totalCandidatos)
        {
            var ofertaRowExportToExcelViewModelList = new List<OfertaRowExportToExcelViewModel>();

            if (ofertaList == null) return ofertaRowExportToExcelViewModelList;

            ofertaRowExportToExcelViewModelList = ofertaList.Select(x => x.ConvertToOfertaExportToExcelRowViewModel(totalCandidatos)).ToList();

            return ofertaRowExportToExcelViewModelList;
        }

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Estado":
                    attributeName = "EstadoOfertaId";
                    break;
                case "FechaPublicacion":
                    attributeName = "FechaPublicacion";
                    break;
                case "Candidatos Inscritos":
                    break;
                case "Centro":
                    attributeName = "Usuario.Centro.Nombre";
                    break;
            }
            return attributeName;
        }

        #region Private Methods

        private static OfertaRowViewModel ConvertToOfertaRowViewModel(this Oferta oferta, Dictionary<int, int> totalCandidatos)
        {
            var ofertRowViewModel = new OfertaRowViewModel()
            {
                OfertaId = oferta.OfertaId,
                Nombre = oferta.Nombre,
                Estado = oferta.EstadoOferta.Nombre,
                Candidatos = totalCandidatos[oferta.OfertaId],
                FechaPublicacion = oferta.FechaPublicacion,
                Centro = oferta.Usuario.CentroId != null ? oferta.Usuario.Centro.Nombre : string.Empty

            };

            return ofertRowViewModel;
        }

        private static OfertaRowViewModel ConvertToOfertaRowViewModelSinCandidatos(this Oferta oferta)
        {
            var ofertRowViewModel = new OfertaRowViewModel()
            {
                OfertaId = oferta.OfertaId,
                Nombre = oferta.Nombre,
                Estado = oferta.EstadoOferta.Nombre,
                FechaPublicacion = oferta.FechaPublicacion,
                Centro = oferta.Usuario.CentroId != null ? oferta.Usuario.Centro.Nombre : string.Empty

            };

            return ofertRowViewModel;
        }

        private static OfertaRowExportToExcelViewModel ConvertToOfertaExportToExcelRowViewModel(this Oferta oferta, Dictionary<int, int> totalCandidatos)
        {
            var ofertRowViewModel = new OfertaRowExportToExcelViewModel()
            {
                //OfertaId = oferta.OfertaId,
                Nombre = oferta.Nombre,
                Estado = oferta.EstadoOferta.Nombre,
                Candidatos = totalCandidatos[oferta.OfertaId],
                FechaPublicacion = oferta.FechaPublicacion.Value.ToShortDateString(),
                Centro = oferta.Usuario.CentroId != null ? oferta.Usuario.Centro.Nombre : string.Empty

            };

            return ofertRowViewModel;
        }


        #endregion

        #endregion
    }
}
