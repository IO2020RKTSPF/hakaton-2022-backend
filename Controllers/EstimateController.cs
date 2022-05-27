using AutoMapper;
using hakaton_2022_backend.Commands.UpdateEstimation;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Queries.GetEstimation;
using hakaton_2022_backend.Queries.GetUserEstimations;
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

    [HttpPut]
    public async Task<IActionResult> UpdateEstimation([FromBody] UpdateEstimationDto updateEstimationDto)
    {
        var updatedEstimation = await _mediator.Send(new UpdateEstimationCommand()
            {Id = updateEstimationDto.EstimationId, ActualValue = updateEstimationDto.ActualValue});

        return Ok(updatedEstimation);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> GetEstimation([FromBody] GetEstimationDto estimationDto)
    {
        var userId = Int32.Parse(User.Claims.First(p => p.Type == "Id").Value);
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
        return Ok(_mapper.Map<EstimationResultDto>(result));
    }

    [HttpGet]
    [Route("byDescription")]
    public Task<IActionResult> GetEstimationByDescription([FromBody] string description)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpGet]
    public async Task<ICollection<EstimationResultDto>> GetUsersEstimations()
    {
        var userId = Int32.Parse(User.Claims.First(p => p.Type == "Id").Value);
        var request = new GetUserEstimationsQuery()
        {
            UserId = userId
        };

        var result = await _mediator.Send(request);
        return _mapper.Map<ICollection<EstimationResultDto>>(result);

    }
}