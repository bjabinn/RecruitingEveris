using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class NecesidadRowExportToExcelViewModel
    {
        [Display(Name = "Ref.")]
        public int Referencia { get; set; }

        public string Cliente { get; set; }

        public string Proyecto { get; set; }

        public string Tecnologia { get; set; }

        public string Perfil { get; set; }

        [Display(Name = "Previsión")]
        public string TipoPrevisionId { get; set; }

        [Display(Name = "Fecha Compromiso")]
        public string FechaCompromiso { get; set; }

        [Display(Name = "Fecha Cierre")]
        public string FechaCierre { get; set; }

        [Display(Name = "Tipo Contratación")]
        public string TipoContratacion { get; set; }

        public string Centro { get; set; }


        public string PersonaAsignada { get; set; }

        public string Estado { get; set; }

        public string AsignadaCorrectamente { get; set; }

        public string Sector { get; set; }

        public string FechaAlta { get; set; }
    }
}
