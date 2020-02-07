﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;
using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Services
{
    public interface ITokenService
    {
        Task<Response> CreateUser(RegistrationRequest registrationRequest);
    }
}