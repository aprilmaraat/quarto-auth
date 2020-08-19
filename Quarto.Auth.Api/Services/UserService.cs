using Quarto.Auth.EF;
using Quarto.Auth.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Quarto.Common.Package;

namespace Quarto.Auth.Services
{
    public class UserService
    {
        private readonly AuthContext _authContext;
        private IAppCache _appCache;

        public UserService(IAppCache appCache, AuthContext authContext)
        {
            _appCache = appCache;
            _authContext = authContext;
        }

        public async Task<Response<UserData>> GetUserData(int id)
        {
            try
            {
                var user = await _authContext.UserData.FirstOrDefaultAsync(user => user.ID == id);
                return Response<UserData>.Success(user);
            }
            catch (Exception ex)
            {
                return Response<UserData>.Error(ex.Message);
            }
        }
    }
}
