using AutoMapper;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Queries.GetEstimation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Controllers;

[ApiController]
[Route("api/estimate")]
public class EstimateController : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;

    public EstimateController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetEstimation([FromBody] GetEstimationDto estimationDto)
    {
        var userId = Int32.Parse(User.Claims.First(p => p.Type == "id").Value);
        var request = new GetEstimationQuery()
        {
            UserId = userId,
            CodeFamiliarity = estimationDto.CodeFamiliarity,
            DesiredCodeQuality = estimationDto.Quality,
            ExperienceLevel = estimationDto.Experience,
            LinesOfCode = estimationDto.Lines,
            ProjectScale = estimationDto.ProjectScale,
            TaskKnowledge = estimationDto.TaskKnowledge,
            UseAi = estimationDto.UseAi
        };

        var result = await _mediator.Send(request);
        return Ok(_mapper.Map<EstimationResultDto>(request));
    }

    [HttpGet]
    [Route("byDescription")]
    public Task<IActionResult> GetEstimationByDescription([FromBody] string description)
    {
        throw new NotImplementedException();
    }
}