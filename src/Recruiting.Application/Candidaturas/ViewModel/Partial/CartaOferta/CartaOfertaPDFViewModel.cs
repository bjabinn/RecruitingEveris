using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CartaOfertaPdfViewModel
    {
        public int CandidaturaId { get; set; }    
        public int CartaOfertaId { get; set; }
        public string Centro { get; set; }
        public string fecha { get; set; }
        public string NombreCandidato { get; set; }
        public string NombreEntregaCarta { get; set; }
        public string CargoEntregaCarta { get; set; }
        public string Categoria { get; set; }
        public string PeriodoPrueba { get; set; }
        public string SalarioBruto { get; set; }
        public string Telefono { get; set; }
        public string TelefonoContratacion { get; set; }
        public string AyudaComedor { get; set; }
        public string SalarioNeto { get; set; }
        public string MailTo { get; set; }
        public string Atencion { get; set; }
        public string LogoCabecera { get; set; }
        public string imagenFirma { get; set; }
        public string Fax { get; set; }
    }
}
