using Recruiting.Application.Candidatos.Services;
using Recruiting.Application.Candidaturas.Services;
using Recruiting.Application.Maestros.Enums;
using Recruiting.Application.Maestros.Services;
using Recruiting.Business.Repositories;
using Recruiting.Data.EntityFramework.Repositories;
using RecruitingWeb.Helpers;
using RecruitingWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace RecruitingWeb.Controllers
{
    public class OtherInfoDropdownsApiController : ApiController
    {
        #region Fields 

        IMaestroRepository _maestroRepository;

        IMaestroService _maestroService;

        #endregion

        #region Construct
        public OtherInfoDropdownsApiController()
        {
            _maestroRepository = new MaestroRepository();

            _maestroService = new MaestroService(_maestroRepository);
        }
        #endregion


        // POST: OtherInfoApi
        public OtherInfoDropdownsModel Post(OtherInfoDropdownsModel model)
        {
            try
            {

                if (ValidateUser(model))
                {
                    model = GenerateDropdownsContactar(model);
                    return model;
                }

            }
            catch (Exception exception)
            {
                return null;
            }
            return model;
        }
        private bool ValidateUser(OtherInfoDropdownsModel model)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (model.UserName == appSettings.Get("userNameOtherInfo") && model.Password == appSettings.Get("passwordOtherInfo"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private OtherInfoDropdownsModel GenerateDropdownsContactar(OtherInfoDropdownsModel model)
        {
            int[] tipoMaestroId =
            {
                (int)MasterDataTypeEnum.Titulacion,
                (int)MasterDataTypeEnum.Categoria,
                (int)MasterDataTypeEnum.TipoTecnologia,
                (int)MasterDataTypeEnum.TipoModulo
            };

            var response = _maestroService.GetDatosMaestroByTipoId(tipoMaestroId);

            model.TitulacionList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Titulacion);
            model.PerfilList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.Categoria);
            model.TecnologiaList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoTecnologia);
            model.ModuloList = ControllerHelper.GenerateElements(response, MasterDataTypeEnum.TipoModulo);

            return model;
        }
    }
   
}