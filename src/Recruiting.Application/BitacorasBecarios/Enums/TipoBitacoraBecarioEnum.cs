using System.ComponentModel;

namespace Recruiting.Application.BitacorasBecarios.Enums
{
    public enum TipoBitacoraBecarioEnum
    {
        [Description("Creacion")]
        Creacion = 1,

        [Description("Cambio de Estado")]
        CambioEstado = 2,

        [Description("Edicion")]
        Edicion = 3,

        [Description("Manual")]
        Manual = 4,

        [Description("Renuncia")]
        Renuncia = 5,

        [Description("Retroceder")]
        Retroceder = 6,

        [Description("Pausar")]
        Pausar = 7,

        [Description("Reanudar")]
        Reanudar = 8,

        [Description("Descarte")]
        Descarte = 9,
    }
}
