using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    public class CreateEditRowIdiomaCandidaturaViewModel
    {
        public int? CandidatoIdiomasId { get; set; }

        public int CandidatoId { get; set; }

        public int IdiomaId { get; set; }

        public string Idioma { get; set; }

        public int NivelIdiomaId { get; set; }

        public string NivelIdioma { get; set; }
    }
}
