using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Maestros.Messages;
using Recruiting.Application.Maestros.ViewModels;
using Recruiting.Application.Necesidades.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace RecruitingWeb.Helpers
{
    public static class ControllerHelper
    {
        private static readonly INecesidadRepository necesidadRepository = new NecesidadRepository();
        private static readonly INecesidadService _necesidadService = new NecesidadService(necesidadRepository);

        public static string RenderRazorViewToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public static IEnumerable<SelectListItem> GenerateElements(GetMaestroListByTipoIdResponse response, MasterDataTypeEnum masterTypeData)
        {
            IEnumerable<MaestroRowViewModel> masterDataList;

            if (masterTypeData == MasterDataTypeEnum.Categoria ||
                masterTypeData == MasterDataTypeEnum.EstadoNecesidad ||
                masterTypeData == MasterDataTypeEnum.TipoTecnologia ||
                masterTypeData == MasterDataTypeEnum.OrigenCv ||
                masterTypeData == MasterDataTypeEnum.FuenteReclutamiento ||
                masterTypeData == MasterDataTypeEnum.MotivoRechazoCartaOferta)
            {
                masterDataList = from value in response.DatosMaestroCollection
                                 where value.TipoMaestroId == (int)masterTypeData && value.Activo
                                 //orderby value.Nombre
                                 select value;

                return new SelectList(masterDataList, "MaestroId", "Nombre");

            }
            else
            {
                masterDataList = from value in response.DatosMaestroCollection
                                 where value.TipoMaestroId == (int)masterTypeData && value.Activo
                                 orderby value.Nombre
                                 select value;

                return new SelectList(masterDataList, "MaestroId", "Nombre");
            }

        }

        public static IEnumerable<SelectListItem> GenerateElementsStaffingTecnologia(GetMaestroListByTipoIdResponse response, MasterDataTypeEnum masterTypeData, string centro)
        {
            IEnumerable<MaestroRowViewModel> masterDataList;
            List<MaestroRowViewModel> tecnologiaList = new List<MaestroRowViewModel>();

            masterDataList = from value in response.DatosMaestroCollection
                             where value.TipoMaestroId == (int)masterTypeData && value.Activo
                             //orderby value.Nombre
                             select value;

            foreach (var tecnologia in masterDataList)
            {
                var comprobar = _necesidadService.ComprobarTecnologia(tecnologia.MaestroId, centro);

                if (comprobar)
                {
                    tecnologiaList.Add(tecnologia);
                }
            }

            return new SelectList(tecnologiaList, "MaestroId", "Nombre");

        }

        public static IEnumerable<SelectListItem> GenerateElementsStaffingPerfil(GetMaestroListByTipoIdResponse response, MasterDataTypeEnum masterTypeData, string centro)
        {
            IEnumerable<MaestroRowViewModel> masterDataList;
            List<MaestroRowViewModel> perfilList = new List<MaestroRowViewModel>();

            masterDataList = from value in response.DatosMaestroCollection
                             where value.TipoMaestroId == (int)masterTypeData && value.Activo
                             //orderby value.Nombre
                             select value;

            foreach (var perfil in masterDataList)
            {
                var comprobar = _necesidadService.ComprobarPerfil(perfil.MaestroId, centro);

                if (comprobar)
                {
                    perfilList.Add(perfil);
                }
            }

            return new SelectList(perfilList, "MaestroId", "Nombre");

        }

        public static IEnumerable<SelectListItem> GenerateElements(int start, int end)
        {
            var dictionary = new Dictionary<int, string>();

            for (int i = start; i <= end; i++)
            {
                dictionary.Add(i, i.ToString());
            }

            return new SelectList(dictionary, "Key", "Value");

        }
    }
}