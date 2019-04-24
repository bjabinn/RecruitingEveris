using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetCentroBecarioResponse : ApplicationResponseBase
    {
        public string NombreCentro { get; set; }
        public int CentroId { get; set; }
    }
}
