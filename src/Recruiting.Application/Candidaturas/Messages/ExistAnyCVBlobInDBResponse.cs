using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class ExistAnyCVBlobInDBResponse : ApplicationResponseBase
    {
        public bool exists { get; set; }
    }
}
