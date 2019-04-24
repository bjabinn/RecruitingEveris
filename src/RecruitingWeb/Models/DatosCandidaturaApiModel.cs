using Recruiting.Application.Candidaturas.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class DatosCandidaturaApiModel
    {       
        public string Categoria { get; set; }

        public string Estado { get; set; }
        public string Etapa { get; set; }

        public string Observaciones { get; set; }

        public string ComentariosRenunciaDescarte { get; set; }

        public DateTime? FechaUltimoContacto { get; set; }

        public string PersonaUltimoContacto { get; set; }

        public DateTime? FechaEntradaCv { get; set; }

    }
}