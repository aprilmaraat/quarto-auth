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

        public async Task<Response<AuthResponse>> Login(PasswordTokenRequest passwordTokenRequest)
        {
            try
            {
                var passwordHasher = new PasswordHasher<string>();
                var user = await _authContext.UserCred
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(u => u.AuthenticationHash == passwordHasher.HashPassword(passwordTokenRequest.EmailAddress, passwordTokenRequest.Password));
                if (user == null)
                    return Response<AuthResponse>.Error("User not found!");
                var response = new AuthResponse()
                {
                    User = new LoginUser()
                    {
                        EmailAddress = user.User.EmailAddress,
                        UserID = user.UserID
                    }
                };

                return Response<AuthResponse>.Success(response);
            }
            catch (Exception ex)
            {
                return Response<AuthResponse>.Error(ex.Message);
            }

            return Response<AuthResponse>.Error("");
        }

        /// <summary>
        /// Used in register endpoint to create a user
        /// </summary>
        /// <param name="registrationRequest"></param>
        /// <returns></returns>
        public async Task<Response> CreateUser(PasswordTokenRequest registrationRequest)
        {
            using (var transaction = _authContext.Database.BeginTransaction())
            {
                try
                {
                    var existUser = await _authContext.UserData
                        .FirstOrDefaultAsync(u => u.EmailAddress == registrationRequest.EmailAddress);

                    if (existUser != null)
                        return Response.Error("Email Address already in use.");

                    var passwordHasher = new PasswordHasher<string>();
                    if (!CheckStringIsEmpty(registrationRequest.EmailAddress)
                        || !CheckStringIsEmpty(registrationRequest.Password))
                    {
                        var newUser = new UserData { EmailAddress = registrationRequest.EmailAddress };
                        await _authContext.UserData.AddAsync(newUser);
                        await _authContext.SaveChangesAsync();
                        await _authContext.UserCred
                                .AddAsync(
                                    new UserCred
                                    {
                                        UserID = newUser.ID,
                                        UserType = registrationRequest.UserType,
                                        AuthenticationHash = passwordHasher.HashPassword(
                                            newUser.EmailAddress
                                            , registrationRequest.Password)
                                    });
                        await _authContext.SaveChangesAsync();
                    }
                    else 
                    {
                        return Response.Error("Email Address or Password is invalid.");
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
