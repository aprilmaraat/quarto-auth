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

        private bool CheckStringIsEmpty(string data) 
        {
            return string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data);
        }

        public async Task<Response> CreateUser(RegistrationRequest registrationRequest)
        {
            using (var transaction = _authContext.Database.BeginTransaction())
            {
                try
                {
                    var existUser = await _authContext.UserData
                        .FirstOrDefaultAsync(u => u.EmailAddress == registrationRequest.UserData.EmailAddress);

                    if (existUser != null)
                        return Response.Error("Email Address already in use.");

                    var passwordHasher = new PasswordHasher<string>();
                    if (!CheckStringIsEmpty(registrationRequest.UserData.EmailAddress)
                        || !CheckStringIsEmpty(registrationRequest.PasswordTokenRequest.Password))
                    {
                        await _authContext.UserData.AddAsync(registrationRequest.UserData);
                        await _authContext.SaveChangesAsync();
                        await _authContext.UserCred
                                .AddAsync(
                                    new UserCred
                                    {
                                        UserID = registrationRequest.UserData.ID,
                                        UserType = registrationRequest.PasswordTokenRequest.UserType,
                                        AuthenticationHash = passwordHasher.HashPassword(
                                            registrationRequest.UserData.EmailAddress
                                            , registrationRequest.PasswordTokenRequest.Password)
                                    });
                        await _authContext.SaveChangesAsync();
                    }
                    else 
                    {
                        return Response.Error("Email Address or Password is invalid. Please check the fields for errors.");
                    }

                    await transaction.CommitAsync();
                    return Response.Success();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response.Error(ex);
                }
            }
        }
    }
}
