using Recruiting.Application.FunnelProcesos.ViewModels;

namespace RecruitingWeb.Models
{
    public class FunnelProcesoGraficasModels
    {
        public bool IsValid { get; set; }

        public DatosFiltradoCVViewModel DatosFiltradoCV { get; set; }

        public DatosEntrevistasViewModel DatosEntrevistas { get; set; }       

        public DatosCartaOfertaViewModel DatosCartaOferta { get; set; }




    }
}