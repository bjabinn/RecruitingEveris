using System.Web.Http;

namespace RecruitingWeb
{
    static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("EnviarCorreosAPI", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}