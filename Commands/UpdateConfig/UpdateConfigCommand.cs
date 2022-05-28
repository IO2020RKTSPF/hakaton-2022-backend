using hakaton_2022_backend.DTOs.Config;
using MediatR;

namespace hakaton_2022_backend.Commands.UpdateConfig;

public class UpdateConfigCommand : IRequest<GetConfigDto>
{
    public int UserId { get; set; }
    public int MinutesPerLines { get; set; }
    public int MinutesPerCodeFamiliarity { get; set; }
    public int MinutesPerExperience { get; set; }
    public int MinutesPerProjectScale { get; set; }
    public int MinutesPerTaskKnowledge { get; set; }
    public int MinutesQuality { get; set; }
    public bool AiUseOnlyInternalEstimations { get; set; }

}