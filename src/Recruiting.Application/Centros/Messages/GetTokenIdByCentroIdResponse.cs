using Recruiting.Application.Base;

namespace Recruiting.Application.Centros.Messages
{
    public class GetTokenIdByCentroIdResponse : ApplicationResponseBase
    {
        public int tokenId { get; set; }
    }
}
