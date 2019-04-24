using Recruiting.Application.Base;
using System;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class SaveCandidaturaResponse : ApplicationResponseBase
    {
        public int CandidaturaId { get; set; }
        public string NombreCV { get; set; }
        public string UbicacionCandidato { get; set; }
        public DateTime? AnioExperiencia { get; set; }
    }
}
