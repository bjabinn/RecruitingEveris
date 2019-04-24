using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class CentroProcedenciaRowViewModel
    {
        public int CentroId { get; set; }
        public string Centro { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }        
    }
}
