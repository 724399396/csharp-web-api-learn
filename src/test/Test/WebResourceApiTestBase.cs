using System;
using System.Net.Http;
using System.Web.Http;
using WebApplication;

namespace Test
{
    public class WebResourceApiTestBase : IDisposable
    {
        readonly HttpServer httpServer;
        protected HttpClient Client { get; }

        public WebResourceApiTestBase()
        {
            httpServer = CreateHttpServer();
            Client = CreateHttpClient();
        }

        HttpClient CreateHttpClient()
        {
            return new HttpClient(httpServer);
        }

        HttpServer CreateHttpServer()
        {
            HttpConfiguration globalConfiguration = new HttpConfiguration();
            Bootstrapper.Init(globalConfiguration);

            return new HttpServer(globalConfiguration);
        }

        public void Dispose()
        {
            httpServer?.Dispose();
            Client?.Dispose();
        }
    }
}