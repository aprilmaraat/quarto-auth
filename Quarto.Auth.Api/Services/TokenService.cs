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

        public async Task<Response<List<UserData>>> GetUsers() 
        {
            try
            {
                var data = await _authContext.UserData.ToListAsync();
                return Response<List<UserData>>.Success(data);
            }
            catch (Exception ex)
            {
                return Response<List<UserData>>.Error(ex);
            }
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
                //return new Response
                //{
                //    State = ResponseState.Success,
                //    Message = ResponseMessage.Success
                //};
                return Response.Success();
            }
            catch (Exception ex)
            {
                return Response.Error(ex);
            }
        }
    }
}
