using System.ComponentModel;

namespace Recruiting.Application.Bitacoras.Enums
{
    public enum TipoBitacoraEnum
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

        [Description("Correo")]
        Correo = 9,

        [Description("Descarte")]
        Descarte = 10,
    }
}
