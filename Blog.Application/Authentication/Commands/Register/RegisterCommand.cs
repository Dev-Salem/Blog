using Blog.Application.Common.Authentication;
using ErrorOr;
using MediatR;

namespace Blog.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Email, string Password, string FirstName, string LastName)
        : IRequest<ErrorOr<AuthenticationResult>>;
}
