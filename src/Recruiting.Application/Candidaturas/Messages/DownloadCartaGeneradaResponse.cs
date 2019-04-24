using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class DownloadCartaGeneradaResponse : ApplicationResponseBase
    {
        
        public byte[] CartaOfertaGenerada { get; set; }
    }
}
