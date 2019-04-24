using Recruiting.Application.Base;

namespace Recruiting.Application.Becarios.Messages
{
    public class DownloadCVResponse : ApplicationResponseBase
    {
        public int BecarioId { get; internal set; }
        public string NombreCV { get; set; }
        public string UrlCV { get; set; }
    }
}
