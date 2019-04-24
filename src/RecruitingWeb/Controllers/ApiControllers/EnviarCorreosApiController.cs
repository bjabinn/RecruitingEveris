using RecruitingWeb.Models;
using System;
using System.Configuration;
using System.Web.Http;

namespace RecruitingWeb.Controllers
{
    public class EnviarCorreosApiController : ApiController
    {

        // POST: EnviarCorreosApi
        public string Post(EverisUserValidatorModel model)
        {           
            var candidaturasController = new CandidaturasController();
            var becariosController = new BecariosController();

            try
            {                
                if(ValidateUser(model))
                {
                    var userId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("correoUserId"));
                    //TODO añadir plantillas centros y URL Feedback.
                    candidaturasController.enviarCorreosRecordatorioFeedback(userId);
                    candidaturasController.enviarCorreosDePrueba(userId);
                    becariosController.EnviarCorreosBecario(userId);
                    return "Correcto";
                }
                
            }
            catch (Exception exception)
            {
                return (exception.Message.ToString());
            }
            return "Usuario o contraseña incorrectos";
        }

        private bool ValidateUser(EverisUserValidatorModel user)
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (user.UserName == appSettings.Get("userNameCorreo") && user.Password == appSettings.Get("passwordCorreo"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}