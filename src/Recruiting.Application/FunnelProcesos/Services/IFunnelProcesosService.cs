using Recruiting.Application.FunnelProcesos.Messages;
using Recruiting.Application.FunnelProcesos.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.FunnelProcesos.Services
{
    public interface IFunnelProcesosService
    {
        #region QueryRequest

        GetDatosDesgloseTecnologiaResponse GetDatosDesgloseTecnologia(DataTableRequest request, IEnumerable<SelectListItem> listaTecnologias);
        GetDatosDesgloseCategoriaResponse GetDatosDesgloseCategoria(DataTableRequest request, IEnumerable<SelectListItem> listaCategorias);
        GetDatosDesgloseTecnologiaCategoriaResponse GetDatosDesgloseTecnologiaCategoria(DataTableRequest request);
        GetDatosFiltradoCVResponse GetDatosFunnelFiltradoCV(FiltroFunnelProcesosViewModel model);
        GetDatosEntrevistasResponse GetDatosFunnelEntrevistas(FiltroFunnelProcesosViewModel model);       
        GetDatosCartaOfertaResponse GetDatosCartaOferta(FiltroFunnelProcesosViewModel model);
        GetCandidaturasModalResponse GetCandidaturasModal(DataTableRequest request);

        #endregion

        #region ActionRequest


        #endregion

    }
}
