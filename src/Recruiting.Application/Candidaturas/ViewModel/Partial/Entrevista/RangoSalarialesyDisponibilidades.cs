using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class RangoSalarialesyDisponibilidades
    {
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal? SalarioPropuesto { get; set; }
        public decimal? SalarioActual { get; set; }
        public bool DisponibilidadViajes { get; set; }
        public bool CambioResidencia { get; set; }
        public int? IncorporacionId { get; set; }
        public string IncorporacionNombre { get; set; }
        public string ObservacionesEntrevista { get; set; }
        public decimal? SalarioDeseado { get; set; }
        public string Moneda { get; set; }
        public bool Filtrado { get; set; }

        public string AccessRango { get; set; }
        public IEnumerable<SelectListItem> IncorporacionList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
    }
}
