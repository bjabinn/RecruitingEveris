using Recruiting.Application.Base;

namespace Recruiting.Application.Becarios.Messages
{
    public class SaveBecarioResponse : ApplicationResponseBase
    {
        public int BecarioId { get; set; }
        public string NombreCV { get; set; }
    }
}
