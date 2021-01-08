using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Quarto.Auth.Models;
using Quarto.Auth.Services;
using System.Text;
using System;
using Quarto.Common.Package;

namespace Quarto.Auth.Controllers
{
    [Route("api/token")]
    public class TokenController : BaseController
    {
        //logging here
        private readonly ITokenService _tokenService;

        public TokenController(IAppCache appCache, ITokenService tokenService) : base(appCache)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Endpoint for logging in to Quarto WebApp
        /// </summary>
        /// <param name="passwordTokenRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PasswordTokenRequest passwordTokenRequest)
        {
            //logger here

            string userAgent = GetUserAgent();

            var response = await _tokenService.Login(passwordTokenRequest, userAgent);

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
        /// Endpoint for registering new user for Quarto WebApp
        /// </summary>
        /// <param name="registrationRequest"></param>
        /// <returns></returns>
        [HttpPost("register")]
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
    }
}
