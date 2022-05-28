using hakaton_2022_backend.Application.Commands.Login;
using hakaton_2022_backend.Application.Commands.Register;
using hakaton_2022_backend.Application.DTOs.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route(("login"))]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginUserRequestDto)
    {
        return Ok(await _mediator.Send(new LoginCommand(loginUserRequestDto.Username, loginUserRequestDto.Password)));
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        return Ok(await _mediator.Send(new RegisterCommand(registerDto.OrganizationName,registerDto.Username, registerDto.Password, registerDto.Email)));
    }
}