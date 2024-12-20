namespace Blog.Application.Services.Authentication
{
    public interface IAuthService
    {
        public AuthenticationResponse Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        );

        public AuthenticationResponse Login(string Email, string Password);
    }
}
