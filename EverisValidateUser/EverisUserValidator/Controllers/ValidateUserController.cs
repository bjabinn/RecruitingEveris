using System.Web.Http;
using EverisUserValidator.Models;
using System.Web.Security;

namespace EverisUserValidator.Controllers
{
    public class ValidateUserController : ApiController
    {
        // GET: /ValidateUser
        /// <summary>
        /// Checks if the services are up and running.
        /// </summary>
        public string Get()
        {
            return "Everis user validation service is on-line";
        }
        // POST: /ValidateUser
        /// <summary>
        /// Validates if an user exists on everis active directory
        /// </summary>
        public bool Post(UserViewModel user)
        {
            try
            {
                var response = Membership.ValidateUser(user.UserName, user.Password);
                return response;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
