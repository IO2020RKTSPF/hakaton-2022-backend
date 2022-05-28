using hakaton_2022_backend.Application.Commands.AddUser;
using hakaton_2022_backend.Application.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Api.Controllers;

[Authorize(Roles = "Owner")]
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewUser([FromBody] AddUserDto addUserDto)
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "Id").Value);
        var result = await _mediator.Send(new AddUserCommand()
            {Password = addUserDto.Password, Username = addUserDto.Password, OwnerId = userId, Email = addUserDto.Email});
        if (result)
            return Ok();
        return BadRequest();
    }
}