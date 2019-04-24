using System.ComponentModel;

namespace Recruiting.Application.BitacorasNecesidades.Enums
{
    public enum TipoBitacoraNecesidadEnum
    {
        [Description("Creacion")]
        Creacion = 1,
               
        [Description("Edicion")]
        Edicion = 2,
        
        [Description("Manual")]
        Manual = 3,     
    }
}
