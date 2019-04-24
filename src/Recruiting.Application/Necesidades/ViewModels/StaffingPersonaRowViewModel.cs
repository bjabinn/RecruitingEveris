using System;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class StaffingPersonaRowViewModel
    {
        public int PersonaId { get; set; }

        public string NombreCompleto { get; set; }

        public int TipoPersonaId { get; set; }

        public string Categoria { get; set; }

        public int? CategoriaId { get; set; }

        public string TipoPersona { get; set; }

    }
}
