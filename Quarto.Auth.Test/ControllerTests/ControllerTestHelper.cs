using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quarto.Auth.Api.Singleton;

namespace Quarto.Auth.Test.ControllerTests
{
    public class ControllerTestHelper
    {
        public static async Task<HttpResponseMessage> POST(string endpoint, object body, string token = "")
        {
            using (HttpClient client = GlobalTest.Server.CreateClient())
            {
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return await client.PostAsync(endpoint
                    , new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            }
        }
    }
}
