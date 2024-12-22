using Blog.Application.Common.Interfaces;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Common.Errors;
using Blog.Domain.Entities;
using ErrorOr;

namespace Blog.Application.Services.Authentication
{
    public class AuthService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        : IAuthService
    {
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public ErrorOr<AuthenticationResult> Login(string Email, string Password)
        {
            if (_userRepository.GetUserByEmail(Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            if (user.Password != Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            var token = _tokenGenerator.GenerateToke(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResult(user, Token: token);
        }

        public ErrorOr<AuthenticationResult> Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        )
        {
            if (_userRepository.GetUserByEmail(Email) != null)
            {
                return Errors.User.DuplicateUser;
            }
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
            };
            var token = _tokenGenerator.GenerateToke(user.Id, user.FirstName, user.LastName);
            _userRepository.Add(user);
            return new AuthenticationResult(user, token);
        }
    }
}
