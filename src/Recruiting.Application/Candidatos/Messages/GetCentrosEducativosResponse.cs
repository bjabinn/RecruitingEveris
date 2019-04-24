using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCentrosEducativosResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidatoCentroEducativoRowViweModel> CentroEducativo { get; set; }
        public int TotalElementos { get; set; }
    }
}
