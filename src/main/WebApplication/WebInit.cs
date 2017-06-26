using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace WebApplication
{
    public class WebInit
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