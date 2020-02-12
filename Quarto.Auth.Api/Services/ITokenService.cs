using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;
using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Services
{
    public interface ITokenService
    {
        Task<Response<List<UserData>>> GetUsers();
        Task<Response> CreateUser(RegistrationRequest registrationRequest);
    }
}
