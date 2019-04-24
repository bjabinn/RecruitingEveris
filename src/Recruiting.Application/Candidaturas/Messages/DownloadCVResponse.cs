using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class DownloadCVResponse : ApplicationResponseBase
    {
        public int CandidaturaId { get; internal set; }
        public string NombreCV { get; set; }
        public string UrlCV { get; set; }
    }
}
