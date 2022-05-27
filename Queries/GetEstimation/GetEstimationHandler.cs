using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Exceptions;
using MediatR;

namespace hakaton_2022_backend.Queries.GetEstimation;

public class GetEstimationHandler : IRequestHandler<GetEstimationQuery, Estimation>
{
    private IConfigRepository _configRepository;
    private IUserRepository _userRepository;
    private IEstimationRepository _estimationRepository;

    public GetEstimationHandler(IConfigRepository configRepository, IUserRepository userRepository, IEstimationRepository estimationRepository)
    {
        _configRepository = configRepository;
        _userRepository = userRepository;
        _estimationRepository = estimationRepository;
    }

    public async Task<Estimation> Handle(GetEstimationQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);
        if (user is null) throw new UserDoesNotExistsException();
        var enterprise = user.Enterprise;
        if (enterprise is null) throw new UserWithoutEnterpriseException();
        var config = await _configRepository.GetConfigByEnterprise(enterprise.Id);
        
        //later do some calculations for that
        var estimation = new Estimation()
        {
            Config = enterprise.Config,
            Result = 555,
            User = user
        };
        var result = await _estimationRepository.AddEstimation(estimation);
        return result;

    }
}