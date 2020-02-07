using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Models
{
    public class RegistrationRequest
    {
        public UserData UserData { get; set; }
        public PasswordTokenRequest PasswordTokenRequest { get; set; }
    }
}
