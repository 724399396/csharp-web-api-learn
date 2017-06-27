using System;
using System.Web.Http;

namespace WebApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var globalConfiguration = GlobalConfiguration.Configuration;

            Bootstrapper.Init(globalConfiguration);
        }
    }
}