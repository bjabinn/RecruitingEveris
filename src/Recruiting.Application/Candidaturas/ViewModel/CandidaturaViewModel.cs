using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaViewModel  {
        public int? CandidaturaId { get; set; }
        public CandidaturaDatosBasicosViewModel CandidaturaDatosBasicosViewModel { get; set; }
        public CandidaturaFiltradoCvViewModel FiltroCVViewModel { get; set; }
        public PrimeraEntrevistaViewModel PrimeraEntrevistaViewModel { get; set; }
        public SegundaEntrevistaViewModel SegundaEntrevistaViewModel { get; set; }
        public CompletarCartaOfertaViewModel CompletarCartaOfertaViewModel { get; set; }
        public string ComentariosRenunciaDescarte { get; set; }
        public int? TipoRenunciaDescarte { get; set; }
        public string TipoRenunciaDescarteNombre { get; set; }
        public string EmailsSeguimiento { get; set; }
        public int? UsuarioCreacionId { get; set; }
        public string UbicacionCandidato { get; set; }
    

        public IEnumerable<SelectListItem> MotivoRenunciaList { get; set; }
        public IEnumerable<SelectListItem> MotivoDescarteList { get; set; }

    }
}
