using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class NecesidadStaffingRowExportToExcelViewModel
    {
        [Display(Name = "Ref.")]
        public int Referencia { get; set; }

        public string Cliente { get; set; }      

        public string Proyecto { get; set; }

        [Display(Name = "Fecha Compromiso")]
        public string FechaCompromiso { get; set; }

        public string Perfil { get; set; }

        public string PersonaAsignada { get; set; }

        public string Observaciones { get; set; }        

    }
}
