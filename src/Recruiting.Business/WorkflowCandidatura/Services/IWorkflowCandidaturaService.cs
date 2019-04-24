using Recruiting.Business.WorkflowCandidatura.Messages;

namespace Recruiting.Business.Services.WorkflowCandidatura
{
    public interface IWorkflowCandidaturaService
    {
        bool IsExecutable(int etapaOrigenId, int? tipoDecisionId, int estadoOrigenId);
        WorkflowResponseDTO Execute(int etapaOrigenId, int? tipoDecisionId);
        string GetVista(int etapaId, int estadoId);
    }
}
