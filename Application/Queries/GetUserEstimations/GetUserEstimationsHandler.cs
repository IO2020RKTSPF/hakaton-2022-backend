using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Repositories;
using MediatR;

namespace hakaton_2022_backend.Application.Queries.GetUserEstimations;

public class GetUserEstimationsHandler : IRequestHandler<GetUserEstimationsQuery, ICollection<Estimation>>
{
    private IEstimationRepository _estimationRepository;

    public GetUserEstimationsHandler(IEstimationRepository estimationRepository)
    {
        _estimationRepository = estimationRepository;
    }

    public async Task<ICollection<Estimation>> Handle(GetUserEstimationsQuery request, CancellationToken cancellationToken)
    {
        var estimations = await _estimationRepository.GetEstimationsForUser(request.UserId);
        return estimations;
    }
}