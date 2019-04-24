using Recruiting.Application.Candidatos.Messages;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Application.Becarios.Messages;
using Recruiting.Application.Becarios.ViewModels;

using Recruiting.Business.BaseClasses.DataTable;
using System;

namespace Recruiting.Application.Becarios.Services
{
    public interface IBecarioService
    {
        #region Query requests

        GetBecarioByIdResponse GetBecarioById(int? becarioId);
        GetBecariosResponse GetBecarios(DataTableRequest request);
        GetBecariosExportToExcelResponse GetBecariosExportToExcel(DataTableRequest request);
        GetBecariosEstadoDescartadoResponse GetBecariosEstadoDescartado();
        GetCentroBecarioResponse GetCentroBecario(int becarioId);
        GetEmailBecarioResponse GetEmailBecario(int becarioId, int tipoMedioContactoEmail);
        SaveBecarioResponse SaveBecario(BecarioDatosBasicosViewModel becarioDatosBasicosViewModel, bool changeEtapa);
        UploadCVResponse UploadCV(byte[] curriculum, int becarioId, string nombreCv);
        RemoveBecarioResponse RemoveBecario(int becarioId);
        EditBecarioResponse SaveEditBecario(CreateEditBecarioViewModel viewModel);
        DownloadCVResponse DownloadCV(int becarioId);
        PauseBecarioResponse PauseBecario(int becarioId, DateTime? fechaContactoStandBy = null);
        ResumeBecarioResponse ResumeBecario(int becarioId);
        ExecuteBecarioResponse ExecuteBecario(int becarioId);
        SaveProcesoBecarioResponse SaveProcesoBecario(BecarioObservacionesViewModel observacionesViewModel, bool changeEtapa);
        SaveSeleccionBecarioResponse SaveSeleccionBecario(BecarioSeleccionViewModel seleccionViewModel, bool changeEtapa);
        UploadCVResponse UploadAnexo(byte[] anexo, int becarioId, string nombreAnexo);
        DownloadAnexoResponse DownloadAnexo(int becarioId);
        SavePracticasBecarioResponse SavePracticasBecario(BecarioDatosPracticasViewModel practicasViewModel, bool changeEtapa);
        RevokeBecarioResponse RevokeBecario(int becarioId,  string ComentariosRenunciaDescarte = null);
        bool CheckBecasAbiertas(int candidatoId);
        BacktrackBecarioResponse BacktrackBecario(int becarioId);
        #endregion
    }
}