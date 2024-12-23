using Blog.Application.Common.Authentication;
using ErrorOr;
using MediatR;

namespace Blog.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password)
        : IRequest<ErrorOr<AuthenticationResult>> { }
}
