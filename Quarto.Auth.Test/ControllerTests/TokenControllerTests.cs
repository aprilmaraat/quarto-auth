using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;
using System.Net.Http;
using System.Text;
using System;

namespace Quarto.Auth.Test.ControllerTests
{
    [TestClass]
    [TestCategory("All/Token")]
    [TestCategory("Controller/Token")]
    public class TokenControllerTests
    {
        public const string baseUrl = "/api/token";
        public PasswordTokenRequest registerRequest = new PasswordTokenRequest
        {
            EmailAddress = "test@unit.test",
            Password = "test123"
        };

        [TestMethod]
        public async Task RegisterUserTest()
        {
            registerRequest.UserType = Models.UserType.LandOwner;

            HttpResponseMessage response = await ControllerTestHelper.POST($"{baseUrl}/register", registerRequest);
            Assert.IsTrue(response.IsSuccessStatusCode);
            //Cleanup
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes("5e2c2534-bba3-45c6-9785-d5990d57028f"));
            response = await ControllerTestHelper.DELETE($"{baseUrl}/test/delete/{registerRequest.EmailAddress}", token);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
