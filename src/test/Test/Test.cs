using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication;
using Xunit;

namespace Test
{
    public class Test
    {
        [Fact]
        public async Task when_get_message_api_should_return_expect_result()
        {
            var httpConfiguration = new HttpConfiguration();
            WebInit.Init(httpConfiguration);
            var httpServer = new HttpServer(httpConfiguration);
            var httpClient = new HttpClient(httpServer);

            var response = await httpClient.GetAsync("http://www.web.com/message");

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            var payload = JsonConvert.DeserializeAnonymousType(content, new
            {
                Message = default(string)
            });
            Assert.Equal(payload.Message, "Hello");
        }
    }
}
