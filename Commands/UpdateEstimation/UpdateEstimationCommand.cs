using hakaton_2022_backend.DTOs.Estimate;
using MediatR;

namespace hakaton_2022_backend.Commands.UpdateEstimation;

public class UpdateEstimationCommand : IRequest<GetEstimationDto>
{
    public int Id { get; set; }
    public int ActualValue { get; set; }
}