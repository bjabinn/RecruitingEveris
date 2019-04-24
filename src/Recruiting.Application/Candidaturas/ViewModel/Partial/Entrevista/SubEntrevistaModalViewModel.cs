using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    public class SubEntrevistaModalViewModel
    {
        public int CandidaturaIdModal { get; set; }
        public int EntrevistadorIdModal { get; set; }
        public string EntrevistadorNameModal { get; set; }
        public DateTime FechaSubEntrevistaModal { get; set; }
        public int TipoSubEntrevistaIdModal { get; set; }
        public bool PresencialModal { get; set; }
        public bool AvisarAlCAndidatoModal { get; set; }

    }
}
