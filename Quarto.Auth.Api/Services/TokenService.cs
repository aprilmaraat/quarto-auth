using Quarto.Auth.EF;
using Quarto.Auth.Models;
using Quarto.Auth.Api.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quarto.Auth.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthContext _authContext;

        public TokenService(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<Response> CreateUser(RegistrationRequest registrationRequest)
        {
            try
            {
                var passwordHasher = new PasswordHasher<string>();
                var newUser = await _authContext.UserData.AddAsync(registrationRequest.UserData);
                await _authContext.SaveChangesAsync();
                await _authContext.UserCred
                        .AddAsync(
                            new UserCred
                            {
                                UserID = registrationRequest.UserData.ID
                                ,
                                UserType = registrationRequest.PasswordTokenRequest.UserType
                                ,
                                AuthenticationHash = passwordHasher.HashPassword(
                                    registrationRequest.PasswordTokenRequest.UserName
                                    , registrationRequest.PasswordTokenRequest.Password)
                            });
                await _authContext.SaveChangesAsync();
                return Response.Success();
            }
            catch (Exception ex)
            {
                return Response.Error(ex);
            }
        }
    }
}
