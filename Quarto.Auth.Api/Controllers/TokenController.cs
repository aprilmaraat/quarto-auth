﻿using Microsoft.AspNetCore.Mvc;
using Quarto.Auth.EF;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Quarto.Auth.Api.Models;

namespace Quarto.Auth.Api.Controllers
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
        public async Task<IActionResult> Post([FromBody] PasswordTokenRequest loginRequest)
        {
            //logger here
            string userAgent = GetUserAgent();

            //if(loginRequest.UserType == 1)


            return new UnauthorizedResult();
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