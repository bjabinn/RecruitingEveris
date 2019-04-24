using Recruiting.Application.Maestros.ViewModels;
using Recruiting.Application.Necesidades.Messages;
using Recruiting.Application.Necesidades.ViewModels;
using Recruiting.Business.BaseClasses.DataTable;
using System;

namespace Recruiting.Application.Necesidades.Services
{
    public interface INecesidadService
    {
        #region Query requests

        GetNecesidadesResponse GetNecesidades(DataTableRequest request);
        GetNecesidadesResponse GetNecesidades();
        GetNecesidadesPersonaLibreResponse GetNecesidadesPersonasLibres();
        GetNecesidadesExportToExcellResponse GetNecesidadesExportToExcel(DataTableRequest request);
        GetNecesidadesStaffingExportToExcelResponse GetNecesidadesStaffingExportToExcel(DataTableRequest request);
        GetNecesidadByIdResponse GetNecesidadById(int necesidadId);
        GetNecesidadesCandidaturaResponse GetNecesidadesCandidatura(DataTableRequest request);
        GetNecesidadesResponse GetNecesidadesByCentroUsuarioId(int CentroUsuarioId);
        GetNecesidadesPersonaLibreResponse GetNecesidadesPersonasLibres(DataTableRequest request);
        GetNecesidadByCandidaturaIdAndCandidatoIdResponse GetNecesidadByCandidaturaIdAndCandidatoId(int candidaturaId, int candidatoId);
        GetNecesidadByNombreCandidatoResponse GetNecesidadByNombreCandidato(string candidato);
        GetStaffingNecesidadesResponse GetStaffingNecesidades(DataTableRequest request);
        GetStaffingPersonasResponse GetStaffingPersonas(DataTableRequest request);
        SaveStaffingNecesidadResponse SaveStaffingNecesidad(SaveStaffingNecesidadViewModel staffingNecesidad);
        SaveObservacionesStaffingResponse SaveObservacionesStaffing(int necesidadId, string observacionesStaffing);
        SavePrioridadNecesidadResponse SavePrioridadNecesidad(SavePrioridadNecesidadViewModel staffingNecesidad);
        CheckLiberateNecesidadResponse CheckLiberateNecesidad(int necesidadId);
        bool ComprobarTecnologia(int tecnologia, string centro);
        bool ComprobarPerfil(int perfil, string centro);

        #endregion

        #region Action requests

        CloneNecesidadResponse CloneNecesidad(int necesidadId);
        DeleteNecesidadResponse DeleteNecesidad(int necesidadId, bool ultNecesidadGrupo);
        SaveNecesidadResponse SaveNecesidad(CreateEditNecesidadViewModel necesidadViewModel);
        SaveNecesidadResponse AbrirNecesidad(int idNecesidad);
        SaveNecesidadResponse CerrarNecesidad(int idNecesidad, DateTime FechaIncorporacion);
        bool CheckUltimaNecesidadEnGrupo(int id);

        #endregion
    }
}
