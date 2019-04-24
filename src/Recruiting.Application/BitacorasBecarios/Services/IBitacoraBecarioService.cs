using Recruiting.Application.BitacorasBecarios.Messages;
using Recruiting.Business.BaseClasses.DataTable;

namespace Recruiting.Application.BitacorasBecarios.Services
{
    public interface IBitacoraBecarioService
    {
        #region QueryRequest
        
        #endregion

        #region ActionRequest
        GenerateBitacoraBecarioResponse GenerateBitacoraCreateBecario(int becarioId);
        GenerateBitacoraBecarioResponse GenerateBitacoraPausarReanudar(int becarioId, int estadoAnteriorId, int estadoNuevoId, bool esPausar);
        GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioIdStandBy(int becarioId);
        GetBitacorasBecarioResponse GetBitacorasByCandidaturaId(DataTableRequest request);
        GenerateBitacoraBecarioResponse GenerateBitacoraBecarioRetroceder(int becarioId, int bitacoraId);
        GenerateBitacoraBecarioResponse GenerateBitacoraDescarteBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId);
        GenerateBitacoraBecarioResponse GenerateBitacoraCambioEstadoBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId);
        GenerateBitacoraEditBecarioResponse GenerateBitacoraEditBecario(int becarioId);
        GenerateBitacoraBecarioResponse GenerateBitacoraBecarioManual(int becarioId, string message);
        GenerateBitacoraBecarioResponse GenerateBitacoraRenunciaBecario(int becarioId, int estadoAnteriorId, int estadoNuevoId);
        GetLastEstadoBitacoraByBecarioIdResponse GetLastEstadoBitacoraByBecarioId(int becarioId);


        #endregion
    }
}
