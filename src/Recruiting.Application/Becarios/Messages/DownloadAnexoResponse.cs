using Recruiting.Application.Base;

namespace Recruiting.Application.Becarios.Messages
{
    public class DownloadAnexoResponse : ApplicationResponseBase
    {
        public int BecarioId { get; internal set; }
        public string NombreAnexo { get; set; }
        public string UrlAnexo { get; set; }
    }
}
