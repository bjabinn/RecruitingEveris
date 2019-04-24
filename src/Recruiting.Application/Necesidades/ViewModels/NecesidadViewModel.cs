using Recruiting.Application.Necesidades.ViewModel.Partial.DatosBasicos;
using System;

namespace Recruiting.Application.Necesidades.ViewModel
{
    [Serializable]
    public class NecesidadViewModel
    {
        public int? NecesidadId { get; set; }
        public NecesidadDatosBasicosViewModel NecesidadDatosBasicosViewModel { get; set; }

    }
}
