namespace Blog.Application.Services.Authentication
{
    public class AuthService : IAuthService
    {
        public AuthenticationResponse Login(string Email, string Password)
        {
            return new AuthenticationResponse(
                Id: Guid.NewGuid(),
                FirstName: "",
                LastName: "",
                Email: Email,
                Token: ""
            );
        }

        public AuthenticationResponse Register(
            string FirstName,
            string LastName,
            string Email,
            string Password
        )
        {
            return new AuthenticationResponse(
                Id: Guid.NewGuid(),
                FirstName: FirstName,
                LastName: LastName,
                Email: Email,
                Token: ""
            );
        }
    }
}
