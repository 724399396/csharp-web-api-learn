using System;
using System.Net.Http;
using System.Web.Http;
using WebApplication;

namespace Test
{
    public class WebResourceApiTestBase : IDisposable
    {
        readonly HttpServer _httpServer;
        protected HttpClient Client { get; }

        public WebResourceApiTestBase()
        {
            _httpServer = CreateHttpServer();
            Client = CreateHttpClient();
        }

        HttpClient CreateHttpClient()
        {
            return new HttpClient(_httpServer)
            {
                BaseAddress = new Uri("http://www.web.com")
            };
        }

        HttpServer CreateHttpServer()
        {
            HttpConfiguration globalConfiguration = new HttpConfiguration();
            Bootstrapper.Init(globalConfiguration);

            return new HttpServer(globalConfiguration);
        }

        public void Dispose()
        {
            _httpServer?.Dispose();
            Client?.Dispose();
        }
    }
}