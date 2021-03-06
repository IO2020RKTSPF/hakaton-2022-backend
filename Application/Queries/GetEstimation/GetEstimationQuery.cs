using hakaton_2022_backend.Core.Entities;
using MediatR;

namespace hakaton_2022_backend.Application.Queries.GetEstimation;

public class GetEstimationQuery : IRequest<Estimation>
{
    public string Name { get; set; }
    public int UserId { get; set; }
    public bool UseAi { get; set; }
    public int LinesOfCode { get; set; }
    public int CodeFamiliarity { get; set; }
    public int ExperienceLevel { get; set; }
    public int ProjectScale { get; set; }
    public int TaskKnowledge { get; set; }
    public int DesiredCodeQuality { get; set; }
}