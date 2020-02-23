using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Quarto.Auth.Api.Models;
using Quarto.Auth.Api.Services;
using Quarto.Auth.Api.Singleton;
using System.Text;
using System;

namespace Quarto.Auth.Api.Controllers
{
    [Route("api/auth")]
    public class TokenController : Controller
    {
        private IAppCache _appCache;
        //logging here
        private readonly ITokenService _tokenService;

        public TokenController(IAppCache appCache, ITokenService tokenService)
        {
            _appCache = appCache;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] PasswordTokenRequest passwordTokenRequest)
        {
            //logger here

            var response = await _tokenService.Login(passwordTokenRequest);

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText); 
                default:
                    return Ok(response);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] PasswordTokenRequest passwordTokenRequest)
        {
            //logger here

            var response = await _tokenService.CreateUser(passwordTokenRequest);

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// The User-Agent request header is a characteristic string 
        /// that lets servers and network peers identify the 
        /// application
        /// , operating system
        /// , vendor
        /// , and/or version 
        /// of the requesting user agent.
        /// </summary>
        /// <returns></returns>
        private string GetUserAgent() 
        {
            StringValues headers = Request.Headers["User-Agent"];
            if (StringValues.IsNullOrEmpty(headers))
                return null;
            return headers[0];
        }

        private bool SecretMatches(string auth)
        {
            if (auth == null || !auth.StartsWith("Bearer "))
            {
                return false;
            }
            else
            {
                string value = auth.Substring("Bearer ".Length);
                try
                {
                    return Encoding.UTF8.GetString(Convert.FromBase64String(value)) == _appCache.AppSecret;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
