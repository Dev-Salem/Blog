using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Application.Services.Authentication
{
    public interface IAuthService
    {
        public AuthenticationResponse Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        );

        public AuthenticationResponse Login(string Email, string Password);
    }
}
