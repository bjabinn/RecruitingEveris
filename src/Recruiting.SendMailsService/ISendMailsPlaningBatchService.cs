using Recruiting.SendMailsService.Correos.Messages;
using Recruiting.SendMailsService.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.SendMailsService
{
    public interface ISendMailsPlaningBatchService
    {
        StringBuilder EnviarEmail(NameValueCollection DiccEstadoCandidaturaPlantillaCorreo, NameValueCollection DiccConfiguracionServidorCorreo, int usuarioAplicacion);
        StringBuilder EnviarAvisosEntrevistas(NameValueCollection DiccAvisoEntrevistaProgramada, NameValueCollection DiccConfiguracionServidorCorreo, int Notificaciones_DiasAntesEntrevista,
          int usuarioAplicacion, string urlRecruiting);

        GetPlantillaCorreoByPlantillaIdResponse GetPlantillaCorreoByPlantillaId(int plantillaId);
        GetPlantillaCorreoByNombreCentroIdResponse GetPlantillaCorreoByNombreCentroId(string NombrePlantillaCorreo, int CentroId);
        GetValorDefectoNombreVariablePlantillaCorreoResponse GetValorDefectoNombreVariablePlantillaCorreo(int PlantillaId, string nombreVariablePlantillaCorreo);


    }
}
