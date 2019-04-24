using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioAsignacionViewModel
    {     
        public int? Asistencia { get; set; }
        public string AsistenciaNombre { get; set; }
        public int? Proyecto { get; set; }
        public string ProyectoNombre { get; set; }
        public int? Cliente { get; set; }
        public string ClienteNombre { get; set; }
        public int? ResponsableId { get; set; }
        public string ResponsableNombre { get; set; }
        public int? TutorId { get; set; }
        public string TutorNombre { get; set; }

        public string AccessAsignacion { get; set; }
    }
}
