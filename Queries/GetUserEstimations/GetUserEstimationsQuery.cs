using hakaton_2022_backend.Entities;
using MediatR;

namespace hakaton_2022_backend.Queries.GetUserEstimations;

public class GetUserEstimationsQuery : IRequest<ICollection<Estimation>>
{
    public int UserId { get; set; }
    public int ResultsPerPage { get; set; }
    public int StartingId { get; set; }
}