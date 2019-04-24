using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting.Application.Necesidades.ViewModel
{
    [Serializable]
    public class NecesidadGrupoRowExportToExcelViewModel
    {
        [Display(Name = "Ref.")]
        public int Referencia { get; set; }

        public string Nombre { get; set; }

        public string Cliente { get; set; }

        public string Proyecto { get; set; }

        public string Estado { get; set; }

        public int NumNecesidades { get; set; }

        public int NumNecesidadesAbiertas { get; set; }

        public int NumNecesidadesPreasignadas { get; set; }

        public int NumNecesidadesCerradas { get; set; }

    }
}
