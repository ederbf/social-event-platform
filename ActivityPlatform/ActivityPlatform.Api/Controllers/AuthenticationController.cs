﻿using SocialEventPlatform.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using SocialEventPlatform.Domain.Common.Errors;
using MediatR;
using SocialEventPlatform.Application.Authentication.Commands.Register;
using SocialEventPlatform.Application.Authentication.Common;
using SocialEventPlatform.Application.Authentication.Queries.Login;
using MapsterMapper;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;

namespace SocialEventPlatform.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            //override default error behavior
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
