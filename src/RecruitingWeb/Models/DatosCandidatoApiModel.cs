using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class DatosCandidatoApiModel
    {
        public bool ExistenteRecruiting { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Titulacion { get; set; }
        public int NumCandidaturas { get; set; }

        public IEnumerable<DatosCandidaturaApiModel> Candidaturas { get; set; }


    }
}