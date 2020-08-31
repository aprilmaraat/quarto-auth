using System;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Quarto.Common.Package;

namespace Quarto.Auth.Controllers
{
    public class BaseController : Controller
    {
        private IAppCache _appCache;

        public BaseController(IAppCache appCache)
        {
            _appCache = appCache;
        }

        /// <summary>
        /// Checkes if the Authorization header matches the app secret
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        private bool SecretMatches(string auth)
        {
            if (auth == null || !auth.StartsWith("Bearer "))
            {
                return false;
            }
            else
            {
                string value = auth.Substring("Bearer ".Length);
                try
                {
                    return Encoding.UTF8.GetString(Convert.FromBase64String(value)) == _appCache.AppSecret;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
