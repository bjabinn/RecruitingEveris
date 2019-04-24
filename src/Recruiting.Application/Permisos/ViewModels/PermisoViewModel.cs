using System;

namespace Recruiting.Application.Permisos.ViewModels
{
    [Serializable]
    public class PermisoViewModel
    {
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
