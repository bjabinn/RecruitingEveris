using Recruiting.Application.Base;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadByCandidaturaIdAndCandidatoIdResponse : ApplicationResponseBase
    {
        public int necesidadId { get; set; }
        public string necesidadNombre { get; set; }
    }
}
