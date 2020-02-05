using Quarto.Auth.EF;
using Quarto.Auth.Models;
using Quarto.Auth.Web.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Quarto.Auth.Web.Services
{
    public class TokenService
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

        private async void CreateUser(UserData user, PasswordTokenRequest registrationRequest) 
        {
            try
            {
                var passwordHasher = new PasswordHasher<string>();
                var newUser = await _authContext.UserData.AddAsync(user);
                if (newUser.State == EntityState.Added)
                    await _authContext.UserCred
                        .AddAsync(
                            new UserCred
                            {
                                UserID = newUser.Entity.ID
                                , UserType = registrationRequest.UserType
                                , AuthenticationHash = passwordHasher.HashPassword(
                                    registrationRequest.UserName
                                    , registrationRequest.Password)
                            });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
