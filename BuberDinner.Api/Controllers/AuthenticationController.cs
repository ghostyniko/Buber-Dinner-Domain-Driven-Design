using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
using BubberDinner.Contracts.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController:ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
       _mediator = mediator;
       _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register (RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        return ProblemOrResult(authResult,sr=>_mapper.Map<AuthenticationResponse>(sr));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login (LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);
        return ProblemOrResult(authResult,sr=>_mapper.Map<AuthenticationResponse>(sr));
    }


}