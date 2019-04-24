using Recruiting.Application.Bitacoras.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.Bitacoras.Services
{
    public interface IBitacoraService
    {
        #region QueryRequest
        GetBitacorasResponse GetBitacorasByCandidaturaId(DataTableRequest request);
        #endregion

        #region ActionRequest
        GenerateBitacoraResponse GenerateBitacoraCreateCandidatura(int candidaturaId);
        GenerateBitacoraResponse GenerateBitacoraCambioEstadoCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int etapaNuevaId, int? decisionId = null);
        GenerateBitacoraResponse GenerateBitacoraEdicionCandidatura(int candidaturaId);
        GenerateBitacoraResponse GenerateBitacoraRenunciaCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int motivoRenunciaId);
        GenerateBitacoraResponse GenerateBitacoraPausarReanudar(int candidaturaId, bool esPausar);
        GenerateBitacoraResponse GenerateBitacoraManual(int candidaturaId, string mensaje);
        GenerateBitacoraResponse GenerateBitacoraCorreo(int candidaturaId, string mensaje);
        GenerateBitacoraResponse GenerateBitacoraRetroceder(int candidaturaId, int bitacoraId);
        GenerateBitacoraResponse GenerateBitacoraDescarteCandidatura(int candidaturaId, int estadoAnteriorId, int estadoNuevoId, int etapaAnteriorId, int motivoDescarteId);
        GetLastBitacoraByCandidaturaIdResponse GetLastBitacoraByCandidaturaId(int candidaturaId);
        GenerateBitacoraResponse GenerateBitacoraCrearCandidaturaOtherInfo(int candidaturaId, string usuarioCreacion);
        #endregion
    }
}
