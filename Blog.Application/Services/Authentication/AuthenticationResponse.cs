using Blog.Domain.Entities;

namespace Blog.Application.Services
{
    public record AuthenticationResponse(User User, string Token);
}
