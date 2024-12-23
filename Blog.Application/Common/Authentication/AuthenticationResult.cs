using Blog.Domain.Entities;

namespace Blog.Application.Common.Authentication
{
    public record AuthenticationResult(User User, string Token);
}
