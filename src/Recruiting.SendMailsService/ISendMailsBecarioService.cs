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
    public interface ISendMailsBecarioService
    {
        StringBuilder EnviarEmailBecario(NameValueCollection DiccEstadoBecarioPlantillaCorreo, NameValueCollection DiccConfiguracionServidorCorreo, int usuarioAplicacion);

        GetPlantillaCorreoByPlantillaIdResponse GetPlantillaCorreoByPlantillaId(int plantillaId);
        GetPlantillaCorreoByNombreCentroIdResponse GetPlantillaCorreoByNombreCentroId(string NombrePlantillaCorreo, int CentroId);
        GetValorDefectoNombreVariablePlantillaCorreoResponse GetValorDefectoNombreVariablePlantillaCorreo(int PlantillaId, string nombreVariablePlantillaCorreo);


    }
}
