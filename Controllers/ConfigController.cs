using BitadAPI.Repositories;
using hakaton_2022_backend.Commands.UpdateConfig;
using hakaton_2022_backend.DTOs;
using hakaton_2022_backend.DTOs.Config;
using hakaton_2022_backend.Queries.GetConfig;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Controllers;

[Authorize]
[ApiController]
[Route("api/config")]
public class ConfigController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConfigController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetConfig()
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "Id").Value);

        var config = await _mediator.Send(new GetConfigQuery() {UserId = userId});
        return Ok(config);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateConfig([FromBody] UpdateConfigDto updateConfigDto)
    {
        var userId = int.Parse(User.Claims.First(x => x.Type == "Id").Value);

        var config = await _mediator.Send(new UpdateConfigCommand()
        {
            UserId = userId,
            MinutesQuality = updateConfigDto.MinutesQuality,
            MinutesPerExperience = updateConfigDto.MinutesPerExperience,
            MinutesPerLines = updateConfigDto.MinutesPerLines,
            MinutesPerCodeFamiliarity = updateConfigDto.MinutesPerCodeFamiliarity,
            MinutesPerProjectScale = updateConfigDto.MinutesPerProjectScale,
            MinutesPerTaskKnowledge = updateConfigDto.MinutesPerTaskKnowledge
        });
        return Ok(config);
    }
}