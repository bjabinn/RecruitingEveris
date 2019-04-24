using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCentrosByNombreCentroEducativoResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidatoCentroEducativoRowViweModel> CentrosProcedencia { get; set; }
    }
}
