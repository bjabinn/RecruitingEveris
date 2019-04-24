using System;

namespace RecruitingWeb.Models
{
    public class FiltroBitacoraBecarioModels
    {
        public int BitacoraId { get; set; }
        public int BecarioId { get; set; }
        public string TipoCambio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
        public int? CentroIdUsuario { get; set; }
        public string MensajeSistema { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public string CentroIdUsuarioLogueado { get; set; }
        public string EstadoBecario { get; set; }
        public string TipoBecario { get; set; }
        public string CentroProcedencia { get; set; }
        public string NombreBecario { get; set; }
        public string CentroUsuarioCreacion { get; set; }


    }
}