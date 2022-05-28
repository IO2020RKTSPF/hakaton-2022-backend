using AutoMapper;
using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Exceptions;
using hakaton_2022_backend.Models;
using hakaton_2022_backend.Services;
using MediatR;

namespace hakaton_2022_backend.Queries.GetEstimation;

public class GetEstimationHandler : IRequestHandler<GetEstimationQuery, Estimation>
{
    private IConfigRepository _configRepository;
    private IUserRepository _userRepository;
    private IEstimationRepository _estimationRepository;
    private IParametersRepository _parametersRepository;
    private readonly IEstimationMachineLearningService _estimationMachineLearningService;
    private readonly IMapper _mapper;

    public GetEstimationHandler(IConfigRepository configRepository, IUserRepository userRepository, IEstimationRepository estimationRepository, IParametersRepository parametersRepository, IEstimationMachineLearningService estimationMachineLearningService, IMapper mapper)
    {
        _configRepository = configRepository;
        _userRepository = userRepository;
        _estimationRepository = estimationRepository;
        _parametersRepository = parametersRepository;
        _estimationMachineLearningService = estimationMachineLearningService;
        _mapper = mapper;
    }

    public async Task<Estimation> Handle(GetEstimationQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);
        if (user is null) throw new UserDoesNotExistsException();
        var enterprise = user.Enterprise;
        if (enterprise is null) throw new UserWithoutEnterpriseException();
        var config = await _configRepository.GetConfigByEnterprise(enterprise.Id);
        var parameters = new Parameters()
        {
            CodeFamiliarity = request.CodeFamiliarity,
            DesiredCodeQuality = request.DesiredCodeQuality,
            ExperienceLevel = request.ExperienceLevel,
            LinesOfCode = request.LinesOfCode,
            ProjectScale = request.ProjectScale,
            TaskKnowledge = request.TaskKnowledge,
            UseAi = request.UseAi
        };

        var paramsDb = await _parametersRepository.AddParameters(parameters);
        
        //later do some calculations for that
        var estimation = new Estimation()
        {
            Parameters = paramsDb,
            Result = await CalculateEstimation(config, parameters),
            User = user
        };
        var result = await _estimationRepository.AddEstimation(estimation);
        return result;

    }

    private async Task<int> CalculateEstimation(Config config, Parameters parameters)
    {
        if (parameters.UseAi)
            return await _estimationMachineLearningService.Calculate(_mapper.Map<EstimationModel>(parameters));
        return (config.MinutesQuality * parameters.DesiredCodeQuality) +
               (config.MinutesPerExperience * (1/parameters.ExperienceLevel)) +
               (config.MinutesPerLines * parameters.LinesOfCode) +
               (config.MinutesPerCodeFamiliarity * (1/parameters.CodeFamiliarity)) +
               (config.MinutesPerProjectScale * parameters.ProjectScale) +
               (config.MinutesPerTaskKnowledge * (1/parameters.TaskKnowledge));
    }
}