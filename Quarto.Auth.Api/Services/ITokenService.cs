using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;
using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Services
{
    public interface ITokenService
    {
        Task<Response<AuthResponse>> Login(PasswordTokenRequest passwordTokenRequest);
        Task<Response> CreateUser(PasswordTokenRequest registrationRequest);
        Task<Response> DeleteUser(string emailAddress);
    }
}
