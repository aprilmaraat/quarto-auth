using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;
using System.Net.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quarto.Auth.EF;

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
            var context = GetApiContext();
            //Cleanup
            var user = context.UserData.Include(u => u.UserCred).FirstOrDefault(u => u.EmailAddress == registerRequest.EmailAddress);
            if (user != null) 
            {
                context.UserCred.Remove(user.UserCred);
                context.SaveChanges();
                context.UserData.Remove(user);
                context.SaveChanges();
            }
            registerRequest.UserType = Models.UserType.LandOwner;
            HttpResponseMessage response = await ControllerTestHelper.POST($"{baseUrl}/register", registerRequest);
            Assert.IsTrue(response.IsSuccessStatusCode);
            //Cleanup
            user = context.UserData.Include(u => u.UserCred).FirstOrDefault(u => u.EmailAddress == registerRequest.EmailAddress);
            if (user != null)
            {
                context.UserCred.Remove(user.UserCred);
                context.SaveChanges();
                context.UserData.Remove(user);
                context.SaveChanges();
            }
            registerRequest.UserType = Models.UserType.Tenant;
            response = await ControllerTestHelper.POST($"{baseUrl}/register", registerRequest);
            Assert.IsTrue(response.IsSuccessStatusCode);
            //Cleanup
            user = context.UserData.Include(u => u.UserCred).FirstOrDefault(u => u.EmailAddress == registerRequest.EmailAddress);
            if (user != null)
            {
                context.UserCred.Remove(user.UserCred);
                context.SaveChanges();
                context.UserData.Remove(user);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public async Task LoginTest() 
        {
            var context = GetApiContext();
            //Cleanup
            var user = context.UserData.Include(u => u.UserCred).FirstOrDefault(u => u.EmailAddress == registerRequest.EmailAddress);
            if (user != null)
            {
                context.UserCred.Remove(user.UserCred);
                context.SaveChanges();
                context.UserData.Remove(user);
                context.SaveChanges();
            }
            registerRequest.UserType = Models.UserType.LandOwner;
            HttpResponseMessage response = await ControllerTestHelper.POST($"{baseUrl}/register", registerRequest);
            Assert.IsTrue(response.IsSuccessStatusCode);
            PasswordTokenRequest loginRequest = new PasswordTokenRequest 
            {
                EmailAddress = registerRequest.EmailAddress,
                Password = registerRequest.Password
            };
            response = await ControllerTestHelper.POST($"{baseUrl}/login", loginRequest);
            Assert.IsTrue(response.IsSuccessStatusCode);
            //Cleanup
            user = context.UserData.Include(u => u.UserCred).FirstOrDefault(u => u.EmailAddress == registerRequest.EmailAddress);
            if (user != null)
            {
                context.UserCred.Remove(user.UserCred);
                context.SaveChanges();
                context.UserData.Remove(user);
                context.SaveChanges();
            }
        }

        private AuthContext GetApiContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
            string connString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=\"Quarto.Master\";User ID=sa;Password=pass123456";
            optionsBuilder.UseSqlServer(connString);
            var result = new AuthContext(optionsBuilder.Options);
            return result;
        }
    }
}
