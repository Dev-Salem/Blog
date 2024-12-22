using Blog.Domain.Entities;

namespace Blog.Application.Services
{
    public record AuthenticationResult(User User, string Token);
}
