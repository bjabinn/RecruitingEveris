using Recruiting.Application.Candidaturas.Messages;
using Recruiting.Application.Candidaturas.ViewModel;
using Recruiting.Business.BaseClasses.DataTable;
using System;

namespace Recruiting.Application.Candidaturas.Services
{
    public interface ICandidaturaService
    {
        #region QueryRequest
        
        GetCandidaturasResponse GetCandidaturas(DataTableRequest request);
        GetCandidaturasExportToExcelResponse GetCandidaturasExportToExcel(DataTableRequest request);
        GetCandidaturaByIdResponse GetCandidaturaById(int candidaturaId);
        GetCandidatoByCandidaturaResponse GetCandidatoByCandidatura(int candidaturaId);
        GetFiltradoCVCandidaturaResponse GetFiltradoCVCandidatura(int candidaturaId);
        GetSchedulePrimeraEntrevistaResponse GetSchedulePrimeraEntrevista(int candidaturaId);
        GetPrimeraEntrevistaResponse GetPrimeraEntrevista(int candidaturaId);
        GetScheduleSegundaEntrevistaResponse GetScheduleSegundaEntrevista(int candidaturaId);
        GetSegundaEntrevistaResponse GetSegundaEntrevista(int candidaturaId);
        GetScheduleCartaOfertaResponse GetScheduleCartaOferta(int candidaturaId);
        GetCartaOfertaResponse GetCartaOferta(int candidaturaId);
        GetEmailEntrevistadorResponse GetEmailEntrevistador(int entrevistadorId, int tipoMedioContactoEmail);

        GetCartaOfertaIdByCandidaturaIdResponse GetCartaOfertaIdByCandidaturaId(int candidaturaId);
        GetCandidaturasByNombreEstadoCandidaturaResponse GetCandidaturasByNombreEstadoCandidatura(string NombreEstadoCandidatura);
        GetCentroCandidaturaResponse GetCentroCandidatura(int candidaturaId);

        GetCandidaturasByIdCandidatoResponse GetCandidaturasByIdCandidato(int candidatoId);
        #endregion

        #region ActionRequest

        ExecuteCandidaturaResponse ExecuteCandidatura(int candidaturaId, bool saltarSegundaEntrevista);
        PauseCandidaturaResponse PauseCandidatura(int candidaturaId, DateTime? fechaContactoStandBy = null);
        ResumeCandidaturaResponse ResumeCandidatura(int candidaturaId);
        RevokeCandidaturaResponse RevokeCandidatura(int candidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte = null);
        SaveCandidaturaResponse SaveCandidatura(CandidaturaDatosBasicosViewModel candidaturaDatosBasicosViewModel, bool changeEtapa);
        DownloadCVResponse DownloadCV(int candidaturaId);
        AsignToOfertaResponse AsignToOferta(int ofertaId, int candidaturaId);
        RemoveOfertaResponse RemoveOferta(int ofertaId, int candidaturaId);
        SaveFiltradoCVCandidaturaResponse SaveFiltradoCVCandidatura(CandidaturaFiltradoCvViewModel filtradoCVViewModel, bool changeEtapa);
        SaveSchedulePrimeraEntrevistaResponse SaveSchedulePrimeraEntrevista(AgendarPrimeraEntrevistaViewModel agendarViewModel, bool changeEtapa);
        SavePrimeraEntrevistaResponse SavePrimeraEntrevista(PrimeraEntrevistaViewModel completarPrimeraEntrevistaViewModel, bool changeEtapa);
        ReschedulePrimeraEntrevistaResponse ReschedulePrimeraEntrevista(int candidaturaId);
        SaveScheduleSegundaEntrevistaResponse SaveScheduleSegundaEntrevista(AgendarSegundaEntrevistaViewModel agendarViewModel, bool changeEtapa);
        SaveSegundaEntrevistaResponse SaveSegundaEntrevista(SegundaEntrevistaViewModel completarSegundaEntrevistaViewModel, bool changeEtapa);
        RescheduleSegundaEntrevistaResponse RescheduleSegundaEntrevista(int candidaturaId);
        SaveScheduleCartaOfertaResponse SaveScheduleCartaOferta(AgendarCartaOfertaViewModel agendarCartaOfertaViewModel, bool changeEtapa);
        SaveCartaOfertaResponse SaveCartaOferta(EntregaCartaOfertaViewModel entregaCartaOfertaViewModel, bool changeEtapa);
        RescheduleCartaOfertaResponse RescheduleCartaOferta(int candidaturaId);
        SaveCartaOfertaAndNecesidadResponse SaveCartaOfertaAndNecesidad(CompletarCartaOfertaViewModel completarCartaOfertaViewModel, bool changeEtapa);
        UploadCVResponse UploadCV( byte[ ] curriculum , int candidaturaId,string nombreCv);

        RemoveCandidaturaResponse RemoveCandidatura(int candidaturaId);
        GetFiltroEnSesionResponse GetFiltroEnSesion();

        UploadCartaOfertaGeneradaResponse UploadCartaOfertaGenerada(byte[] cartaOfertaGenerada, int CandidaturaId);
        DownloadCartaGeneradaResponse DownloadCartaOfertaGenerada(int cartaOfertaId);
        GetCandidaturaToGeneratePDFbyIdResponse GetCandidaturaToGeneratePDFbyId(int candidaturaId, string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string telefonoContratacion, string mailTo, string atencionTelefonica, string ayudaComedor,string fax);
        GetCandidaturaToGeneratePDFbyIdResponse GetCandidaturaToGeneratePDFbyIdIndex(int candidaturaId, string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string mailTo, string atencionTelefonica, string ayudaComedor, string fax);
        BacktrackCandidaturaResponse BacktrackCandidatura(int candidaturaId);
        EditCandidaturaResponse SaveEditCandidatura(CandidaturaViewModel viewModel, string nombreEntregaCarta, string cargoEntregaCarta, string telefono, string telefonoContratacion, string mailTo, string atencionTelefonica, string ayudaComedor,string fax,string textoCartaOfertaPDF);

        VuelcaCVsEnRutaLocalYActualizaBdResponse VuelcaCVsEnRutaLocalYActualizaBd();
        ExistAnyCVBlobInDBResponse ExistAnyCVBlobInDB();
        #endregion
        EstoyEnCandidaturaEstadoPendienteEntrevistaDosResponse EstoyEnCandidaturaEstadoPendienteEntrevistaDos(int candidaturaId);

        UpdateSubEntrevistasResponse UpdateSubEntrevistas(SubEntrevistaListViewModel SubEntrevistas);
        TieneSubEntrevistasSinCompletarResponse TieneSubEntrevistasSinCompletar(int candidaturaId, int tipoEntrevistaId);

        GetListaSubEntrevistasResponse GetListaSubEntrevistas(int candidaturaId, int tipoEntrevista);
        GetListaSubEntrevistasByEntrevistaIdResponse GetListaSubEntrevistasByEntrevistaId(int entrevistaId);
        GetMonedaCandidaturaResponse GetMonedaCandidatura(int candidaturaId);
        AddSubEntrevistaFromModalResponse AddSubEntrevistaFromModal(SubEntrevistaModalViewModel subEntrevistaFromModal, int tipoEntrevista);
        TieneAvisoConLaMismaFechaSubEntrevistaResponse TieneAvisoConLaMismaFechaSubEntrevista(System.DateTime[] fechas, int candidaturaId, int tipoEntrevista);
        SaveNumeroDeEntrevistasResponse SaveNumeroDeEntrevistas(int candidaturaId);
        UpdateNumeroDeEntrevistasResponse UpdateNumeroDeEntrevistas();
        bool CheckCandidaturasAbiertas(int candidatoId);
        DiscardCandidaturaResponse DiscardCandidatura(int candidaturaId, int TipoRenunciaDescarte, string ComentariosRenunciaDescarte = null);
        RecontactarCandidaturaResponse RecontactarCandidaturaActual(CandidaturaViewModel candidaturaViewModel);
        CrearCandidaturaRecontactadaResponse CrearCandidaturaRecontactada(CandidaturaViewModel candidaturaViewModel);
        RevertirCandidaturaRecontactadaResponse RevertirCandidaturaRecontactada(CandidaturaViewModel candidaturaViewModel);
        void CheckAndOpenNecesidades(int candidaturaId, int candidatoId);
        SaveEmailSeguirCandidaturaResponse SaveEmailSeguirCandidatura(int id, string email);
        DeleteEmailSeguirCandidaturaResponse DeleteEmailSeguirCandidatura(int id, string email);
        CrearCandidaturaBecarioResponse CrearCandidaturaBecario(DatosBecarioCrearViewModel becarioCrear);

        CheckEnProcesoResponse CheckEnProceso(int candidatoId);
        CheckDescarteMenosSeisMesesResponse CheckDescarteMenosSeisMeses(int candidatoId);
        CheckNoMotivadoCambioEmpresaResponse CheckNoMotivadoCambioEmpresa(int candidatoId);

        CrearCandidaturaOtherInfoResponse CrearCandidaturaOtherInfo(DatosCandidaturaOtherInfoViewModel model);
    }
}
