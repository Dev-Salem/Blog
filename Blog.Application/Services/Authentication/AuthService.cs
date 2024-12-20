using Blog.Application.Common.Interfaces;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Entities;

namespace Blog.Application.Services.Authentication
{
    public class AuthService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        : IAuthService
    {
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public AuthenticationResponse Login(string Email, string Password)
        {
            if (_userRepository.GetUserByEmail(Email) is not User user)
            {
                throw new Exception("User does not exist");
            }
            if (user.Password != Password)
            {
                throw new Exception("Password is incorrect");
            }
            var token = _tokenGenerator.GenerateToke(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResponse(user, Token: token);
        }

        public AuthenticationResponse Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        )
        {
            if (_userRepository.GetUserByEmail(Email) != null)
            {
                throw new Exception("User already registered");
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
            return new AuthenticationResponse(user, token);
        }
    }
}
