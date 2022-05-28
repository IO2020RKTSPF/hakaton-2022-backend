using hakaton_2022_backend.Core.Entities;
using MediatR;

namespace hakaton_2022_backend.Application.Queries.GetUserEstimations;

public class GetUserEstimationsQuery : IRequest<ICollection<Estimation>>
{
    public int UserId { get; set; }
}