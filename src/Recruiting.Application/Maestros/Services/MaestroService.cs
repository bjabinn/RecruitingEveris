using Recruiting.Application.Maestros.Mappers;
using Recruiting.Application.Maestros.Messages;
using Recruiting.Business.Entities;
using Recruiting.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruiting.Application.Maestros.Services
{
    public class MaestroService : IMaestroService
    {
        #region Fields

        private readonly IMaestroRepository _maestroRepository;

        #endregion

        #region Constructors

        public MaestroService(IMaestroRepository maestroRepository)
        {
            _maestroRepository = maestroRepository;
        }

        #endregion

        #region IMaestroService

        public GetMaestroListByTipoIdResponse GetDatosMaestroByTipoId(params int[] tipoMaestroId)
        {

            var response = new GetMaestroListByTipoIdResponse();

            try
            {
                var centroIdUsuarioLogueado = "";

                if (HttpContext.Current.Session == null)
                {
                    centroIdUsuarioLogueado = "98";
                }
                else
                {
                    centroIdUsuarioLogueado = HttpContext.Current.Session["CentroIdUsuario"] != null ? HttpContext.Current.Session["CentroIdUsuario"].ToString() : string.Empty;
                }

                var maestroList = RetrieveDatosMaestroByTipoId(tipoMaestroId, centroIdUsuarioLogueado);

                response.DatosMaestroCollection = maestroList.ConvertToDatosMaestroViewModel();

                response.TotalElementos = response.DatosMaestroCollection.Count();
                response.IsValid = true;
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public GetTipoMedioContactoEmailResponse GetTipoMedioContactoEmail(int tipoMaestroId, string nombreMaestroEmail)
        {
            var response = new GetTipoMedioContactoEmailResponse();

            try
            {
                var maestros = _maestroRepository.GetByCriteria(x => x.TipoMaestroId == tipoMaestroId);
                response.idMaestroTipoMedioContactoEmail = maestros.FirstOrDefault(x => x.Nombre.ToUpper() == nombreMaestroEmail.ToUpper()).MaestroId;

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

        private List<Maestro> RetrieveDatosMaestroByTipoId(int[] tipoMaestroId, string centroIdUsuarioLogueado)
        {
            var maestroList = new List<Maestro>();

            if (!string.IsNullOrEmpty(centroIdUsuarioLogueado))
            {

                var datosMaestroGenericos = _maestroRepository
                .GetByCriteria(x => tipoMaestroId.Contains(x.TipoMaestroId) && x.CentroId == null)
                .OrderBy(p => p.TipoMaestroId)
                .GroupBy(x => x.TipoMaestroId)
                .ToList()
                .Select(g => g.OrderBy(e => e.Orden)).ToList();

                foreach (var item in datosMaestroGenericos)
                {
                    maestroList.AddRange(item);
                }

                var centroBuscar = Convert.ToInt32(centroIdUsuarioLogueado);
                var datosMaestroCentro = _maestroRepository
                .GetByCriteria(x => tipoMaestroId.Contains(x.TipoMaestroId) && x.CentroId == centroBuscar)
                .OrderBy(p => p.TipoMaestroId)
                .GroupBy(x => x.TipoMaestroId)
                .ToList()
                .Select(g => g.OrderBy(e => e.Orden)).ToList();

                foreach (var item in datosMaestroCentro)
                {
                    maestroList.AddRange(item);
                }
            }
            else
            {
                var datosMaestroGenericos = _maestroRepository
                .GetByCriteria(x => tipoMaestroId.Contains(x.TipoMaestroId))
                .OrderBy(p => p.TipoMaestroId)
                .GroupBy(x => x.TipoMaestroId)
                .ToList()
                .Select(g => g.OrderBy(e => e.Orden)).ToList();

                foreach (var item in datosMaestroGenericos)
                {
                    maestroList.AddRange(item);
                }
            }

            return maestroList;
        }

        #endregion
    }
}
