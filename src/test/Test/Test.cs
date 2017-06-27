using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Test
{
    public class Test : WebResourceApiTestBase
    {
        [Fact]
        public async Task when_get_message_api_should_return_expect_result()
        {
            var response = await Client.GetAsync("http://www.web.com/message");

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
