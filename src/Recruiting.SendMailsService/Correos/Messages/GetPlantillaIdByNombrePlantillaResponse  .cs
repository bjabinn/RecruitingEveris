using Recruiting.Application.Base;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetPlantillaIdByNombrePlantillaResponse : ApplicationResponseBase
    {
        public int PlantillaId { get; set; }
    }
}
