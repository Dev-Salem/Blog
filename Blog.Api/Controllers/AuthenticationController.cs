using Blog.Application.Authentication.Commands.Register;
using Blog.Application.Authentication.Queries.Login;
using Blog.Application.Common.Authentication;
using Blog.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController(ISender service) : ApiController
    {
        private readonly ISender _mediatR = service;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(
                FirstName: request.FirstName,
                LastName: request.LastName,
                Email: request.Email,
                Password: request.Password
            );
            var authResult = await _mediatR.Send(command);
            return authResult.Match(
                value => Ok(MapAuthenticationResult(value)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult value)
        {
            return new AuthenticationResponse(
                Id: value.User.Id,
                FirstName: value.User.FirstName,
                LastName: value.User.LastName,
                Email: value.User.Email,
                Token: value.Token
            );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(Email: request.Email, Password: request.Password);
            var authResult = await _mediatR.Send(query);
            return authResult.Match(value => Ok(MapAuthenticationResult(value)), Problem);
        }
    }
}
