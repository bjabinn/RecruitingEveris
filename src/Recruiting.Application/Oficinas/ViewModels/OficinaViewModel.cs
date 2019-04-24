using System;

namespace Recruiting.Application.Oficinas.ViewModels
{
    [Serializable]
    public class OficinaViewModel
    {
        public int? OficinaId { get; set; }     
        public string Nombre { get; set; }
        public int? Centro { get; set; }
    }
}
