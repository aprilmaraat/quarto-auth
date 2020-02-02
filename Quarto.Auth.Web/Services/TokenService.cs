using Quarto.Auth.Models.Entities;
using Quarto.Auth.Web.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

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

        //private async Task<BusinessUser> GetUser(string username, string password)
        //{
        //    try
        //    {
        //        PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        //        UserData user = await _authContext.UserData
        //            .FirstOrDefaultAsync(a => a.UserName.ToLower() == username.ToLower());
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        private async void CreateUser(UserData user, string password) 
        {
            try
            {
                await _authContext.UserData.AddAsync(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
