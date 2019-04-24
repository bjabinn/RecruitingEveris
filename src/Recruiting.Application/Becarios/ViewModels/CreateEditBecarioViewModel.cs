using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class CreateEditBecarioViewModel
    {
        public int? BecarioId { get; set; }       
        public bool Activo { get; set; }

        public BecarioDatosBasicosViewModel BecarioDatosBasicos { get; set; }
        public BecarioObservacionesViewModel BecarioObservaciones { get; set; }
        public BecarioSeleccionViewModel BecarioSeleccion { get; set; }
        public BecarioDatosPracticasViewModel BecarioDatosPracticas { get; set; }
        public string ComentariosRenuncia { get; set; }

        public string AccessObservaciones { get; set; }
        public string AccessSeleccion { get; set; }
        public string AccessPracticas { get; set; }
        public string AccessAsignacion { get; set; }
        public string AccessGestion { get; set; }
        public string Access { get; set; }

    }
}
