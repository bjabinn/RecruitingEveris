using Recruiting.Application.Candidatos.Messages;
using Recruiting.Application.Candidatos.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Candidatos.Services
{
    public interface ICandidatoService
    {
        #region Query requests
        GetCandidatosResponse GetCandidatosCandidatura(DataTableRequest request, bool contarCandidaturas = true);
        GetCandidatosResponse GetCandidatosBecario(DataTableRequest request, bool contarBecas = true);
        GetCandidatosExportToExcelResponse GetCandidatosExportToExcel(DataTableRequest request);
        GetCandidatoByIdResponse GetCandidatoById (int candidatoId);
        SearchCandidatoByNumeroIdentificacionResponse SearchCandidatoByNumeroIdentificacion(string numeroIdentificacion, int? idCandidato);
        SearchCandidatoByContactoResponse SearchCandidatoByContactoResponse(string contacto, int? idCandidato);
        GetCandidatosResponse GetCandidatosByCentroUsuarioId(int CentroUsuarioId);
        SearchCandidatoByNombreYApellidosResponse SearchCandidatoByNombreYApellidos(string Nombres, string apellidos, int? idCandidato);
        TieneCVEnBDResponse TieneCVEnBD(int candidatoId);
        GetCandidatosQueCumplenPerfilResponse GetCandidatosQueCumplenPerfil(DataTableRequest request);
        GetCandidatoCandidaturasModalResponse GetCandidatoCandidaturasModal(DataTableRequest request);
        GetCandidatoBecariosModalResponse GetCandidatoBecariosModal(DataTableRequest request);

        CheckCandidatoEnRecruitingResponse CheckCandidatoEnRecruiting(string Nombre, string Email, string Telefono, string NIF);
        UpdateCandidatoOtherInfoResponse UpdateCandidatoOtherInfo(CandidatoOtherInfoViewModel candidato);
        CreateCandidatoOtherInfoResponse CreateCandidatoOtherInfo(CandidatoOtherInfoViewModel candidato);

        #endregion


        #region Action requests

        #region Candidato

        Candidaturas.Messages.DownloadCVResponse DownloadLastCV(int candidatoId);
        SearchCandidatoUsadoResponse SearchCandidatoUsado(int candidatoId);
        SaveCandidatoResponse SaveCandidato (CreateEditCandidatoViewModel candidatoViewModel);
        DeleteCandidatoResponse DeleteCandidato(int candidatoId);
        GetEmailCandidatoResponse GetEmailCandidato(int CandidatoId, int tipoMedioContactoEmail);


        #endregion

        #endregion
    }
}