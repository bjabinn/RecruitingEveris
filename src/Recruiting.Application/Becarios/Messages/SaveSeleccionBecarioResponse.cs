using Recruiting.Application.Base;

namespace Recruiting.Application.Becarios.Messages
{
    public class SaveSeleccionBecarioResponse : ApplicationResponseBase
    {
        public int BecarioId { get; set; }
        public string NombreAnexo { get; set; }
    }
}
