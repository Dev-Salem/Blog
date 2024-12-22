using ErrorOr;

namespace Blog.Application.Services.Authentication
{
    public interface IAuthService
    {
        public ErrorOr<AuthenticationResult> Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        );

        public ErrorOr<AuthenticationResult> Login(string Email, string Password);
    }
}
