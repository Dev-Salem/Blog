using Blog.Application.Common.Authentication;
using Blog.Application.Common.Interfaces.Authentication;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Common.Errors;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Blog.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(
        IJwtTokenGenerator tokenGenerator,
        IUserRepository userRepository
    ) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,
            CancellationToken cancellationToken
        )
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(command.Email) != null)
            {
                return Errors.User.DuplicateUser;
            }
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
            };
            var token = _tokenGenerator.GenerateToke(user.Id, user.FirstName, user.LastName);
            _userRepository.Add(user);
            return new AuthenticationResult(user, token);
        }
    }
}
