using hakaton_2022_backend.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController
{
    [HttpPost]
    [Route(("login"))]
    public Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("register")]
    public Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}