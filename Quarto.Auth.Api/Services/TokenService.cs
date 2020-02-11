using Quarto.Auth.EF;
using Quarto.Auth.Models;
using Quarto.Auth.Api.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Quarto.Auth.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthContext _authContext;

        public TokenService(AuthContext authContext)
        {
            _authContext = authContext;
        }

        //public async Task<TokenServiceLoginResult> Login(IPasswordTokenRequest value)
        //{
        //    try
        //    {
        //        AuthResponse loginResponse = 
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        //private async Task<AuthResponse> GenerateLoginResponse(IPasswordTokenRequest value)
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    { }
        //}

        //private async Task<LoginUser> GetUser(string userName, string password)
        //{
        //    try
        //    {
        //        PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        //        UserData user = await _authContext.UserData
        //            .Include(u => u.UserCred)
        //            .FirstOrDefaultAsync(u => u.UserName == userName);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public async Task<Response> CreateUser(RegistrationRequest registrationRequest)
        {
            try
            {
                var passwordHasher = new PasswordHasher<string>();
                var newUser = await _authContext.UserData.AddAsync(registrationRequest.UserData);
                await _authContext.SaveChangesAsync();
                if (newUser.State == EntityState.Added)
                    await _authContext.UserCred
                        .AddAsync(
                            new UserCred
                            {
                                UserID = newUser.Entity.ID
                                , UserType = registrationRequest.PasswordTokenRequest.UserType
                                , AuthenticationHash = passwordHasher.HashPassword(
                                    registrationRequest.PasswordTokenRequest.UserName
                                    , registrationRequest.PasswordTokenRequest.Password)
                            });
                return new Response
                {
                    State = ResponseState.Success,
                    Message = ResponseMessage.Success
                };
            }
            catch (Exception ex)
            {
                return new Response 
                { 
                    State = ResponseState.Exception,
                    Message = ResponseMessage.Exception,
                    ErrorText = null,
                    Exception = ex
                };
            }
        }
    }
}
