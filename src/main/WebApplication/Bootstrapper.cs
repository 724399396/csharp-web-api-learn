using System.Web.Http;

namespace WebApplication
{
    public class Bootstrapper
    {
        public static void Init(HttpConfiguration globalConfiguration)
        {
            globalConfiguration.Routes.MapHttpRoute("name", "message", new
            {
                controller = "Message"
            });
        }
    }
}