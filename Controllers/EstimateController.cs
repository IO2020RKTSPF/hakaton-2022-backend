using hakaton_2022_backend.DTOs.Estimate;
using Microsoft.AspNetCore.Mvc;

namespace hakaton_2022_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstimateController
{
    [HttpGet]
    public Task<IActionResult> GetEstimation([FromBody] GetEstimationDto estimationDto)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("byDescription")]
    public Task<IActionResult> GetEstimationByDescription([FromBody] string description)
    {
        throw new NotImplementedException();
    }
}