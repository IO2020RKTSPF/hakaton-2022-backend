using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using MediatR;

namespace hakaton_2022_backend.Queries.GetUserEstimations;

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
        if (request.StartingId != -1)
        {
            estimations = estimations.SkipWhile(x => x.Id != request.StartingId).ToList();
        }

        if (estimations.Count > request.ResultsPerPage)
        {
            estimations = estimations.Take(request.ResultsPerPage).ToList();
        }
        
        return estimations;
    }
}