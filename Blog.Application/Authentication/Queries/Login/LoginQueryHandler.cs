namespace Blog.Application.Authentication.Queries.Login;

using Blog.Application.Common.Authentication;
using Blog.Application.Common.Interfaces.Authentication;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Domain.Common.Errors;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;

public class LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _tokenGenerator.GenerateToke(user.Id, user.FirstName, user.LastName);
        return new AuthenticationResult(user, Token: token);
    }
}
