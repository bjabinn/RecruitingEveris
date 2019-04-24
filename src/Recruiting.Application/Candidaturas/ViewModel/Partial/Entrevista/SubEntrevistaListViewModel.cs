using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    public class SubEntrevistaListViewModel
    {
        public List<SubEntrevistaViewModel> SubEntrevistaList { get; set; }
        public int TipoEntrevista { get; set; }
        public bool Editar { get; set; }
        public bool VengoDeCandidaturas { get; set; }
        public string Moneda { get; set; }
        public IEnumerable<SelectListItem> TipoSubEntrevistaList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> IncorporacionList { get; set; }
        public int CandidaturaId { get; set; }
        public string NombreCandidato { get; set; }
    }
}
