using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quarto.Auth.Models;

namespace Quarto.Auth.Services
{
    public interface ITokenService
    {
        Task<Response<AuthResponse>> Login(PasswordTokenRequest passwordTokenRequest, string userAgent);
        Task<Response> CreateUser(PasswordTokenRequest registrationRequest);
    }
}
