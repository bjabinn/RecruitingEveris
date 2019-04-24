using System;

namespace Recruiting.Application.Bitacoras.ViewModels
{
    [Serializable]
    public class BitacoraRowExportToExcelViewModel
    {
        public string TipoCambio { get; set; }

        public string MensajeSistema { get; set; }

        public string Observaciones { get; set; }

        public string Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Centro { get; set; }

    }
}
