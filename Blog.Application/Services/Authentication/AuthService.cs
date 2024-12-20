using Blog.Application.Common.Interfaces;

namespace Blog.Application.Services.Authentication
{
    public class AuthService(IJwtTokenGenerator tokenGenerator) : IAuthService
    {
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

        public AuthenticationResponse Login(string Email, string Password)
        {
            return new AuthenticationResponse(
                Id: Guid.NewGuid(),
                FirstName: "",
                LastName: "",
                Email: Email,
                Token: ""
            );
        }

        public AuthenticationResponse Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        )
        {
            var userId = Guid.NewGuid();
            var token = _tokenGenerator.GenerateToke(userId, FirstName, LastName);
            return new AuthenticationResponse(
                Id: userId,
                FirstName: FirstName,
                LastName: LastName,
                Email: Email,
                Token: token
            );
        }
    }
}
