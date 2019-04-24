using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class OtherInfoRowModel
    {
        public int InfoDataId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string NIF { get; set; }
        public DateTime? FechaExtraccion  { get; set; }
        public bool ExistenteRecruiting { get; set; }
        public bool EnProceso { get; set; }
        public bool NoMotivadoCambioEmpresa { get; set; }
        public bool DescarteRenunciaMenosSeisMeses { get; set; }
        public bool Visualizable { get; set; }
        public bool DecisionTomadaMenosSeisMeses { get; set; }
        public bool Contratado { get; set; }


    }
}