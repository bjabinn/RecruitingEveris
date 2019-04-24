using System;

namespace Recruiting.SendMailsService.Correos.ViewModels
{
    [Serializable]
    public class CorreoPlantillaRowViewModel
    {
        public int PlantillaId { get; set; }

        public string TextoPlantilla { get; set; }

        public string NombrePlantilla { get; set; }

        public bool Activo { get; set; }

        public int CandidatoId { get; set; }
        

    }
}
 
