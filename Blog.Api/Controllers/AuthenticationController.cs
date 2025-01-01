using System.Globalization;
using Blog.Application.Authentication.Commands.Register;
using Blog.Application.Authentication.Queries.Login;
using Blog.Application.Common.Authentication;
using Blog.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController(ISender service, IMapper mapper) : ApiController
    {
        private readonly ISender _mediatR = service;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var authResult = await _mediatR.Send(command);
            return authResult.Match(
                value => Ok(_mapper.Map<AuthenticationResponse>(value)),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediatR.Send(query);
            return authResult.Match(
                value => Ok(_mapper.Map<AuthenticationResponse>(value)),
                errors => Problem(errors)
            );
        }
    }
}
