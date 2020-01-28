using Microsoft.AspNetCore.Mvc;
using Auth.Models.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Auth.Web.Models;

namespace Auth.Web.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly AuthContext _authContext;
        //logging here

        public TokenController(AuthContext authContext)
        {
            _authContext = authContext;
        }

        [HttpPost]
        //[HttpOptions]
        public async Task<IActionResult> Post([FromBody] PasswordTokenRequest loginRequest)
        {
            string userAgent = GetUserAgent();
            return new UnauthorizedResult();
        }

        private string GetUserAgent() 
        {
            StringValues headers = Request.Headers["User-Agent"];
            if (StringValues.IsNullOrEmpty(headers))
                return null;
            return headers[0];
        }
    }
}
