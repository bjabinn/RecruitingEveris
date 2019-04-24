
namespace Recruiting.Business.WorkflowCandidatura.Messages
{
    public class WorkflowResponseDTO
    {
        public bool IsValid { get; set; }
        public int? EtapaFinId { get; set; }
        public int? EstadoFinId { get; set; }
    }
}
