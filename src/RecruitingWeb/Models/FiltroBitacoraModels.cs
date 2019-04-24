using System;

namespace RecruitingWeb.Models
{
    public class FiltroBitacoraModels
    {
        public int BitacoraId { get; set; }
        public int CandidaturaId { get; set; }
        public string TipoCambio { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
        public int? CentroIdUsuario { get; set; }
        public string MensajeSistema { get; set; }

        public string SortColumn { get; set; }
        public Recruiting.Business.BaseClasses.DataTable.DataTableSortDirectionEnum SortOrder { get; set; }

        public string CentroIdUsuarioLogueado { get; set; }
        public string EstadoCandidatura { get; set; }
        public string EtapaCandidatura { get; set; }
        public string Perfil { get; set; }
        public string Entrevistador { get; set; }
        public string NombreCandidato { get; set; }
        public string TipoTecnologia { get; set; }
        public string CentroUsuarioCreacion { get; set; }


    }
}