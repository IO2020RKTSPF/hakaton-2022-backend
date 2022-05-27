using hakaton_2022_backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    //TODO:get user org from jwt claim
    [HttpGet]
    public Task<IActionResult> GetConfig()
    {
        throw new NotImplementedException();
    }
    
    //TODO:get user org from jwt claim
    [HttpPut]
    public Task<IActionResult> UpdateConfig([FromBody] UpdateConfigDto updateConfigDto)
    {
        throw new NotImplementedException();
    }
}