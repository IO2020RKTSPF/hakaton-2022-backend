using AutoMapper;
using BitadAPI.Repositories;
using hakaton_2022_backend.DTOs.Config;
using hakaton_2022_backend.Exceptions;
using MediatR;

namespace hakaton_2022_backend.Commands.UpdateConfig;

public class UpdateConfigHandler : IRequestHandler<UpdateConfigCommand, GetConfigDto>
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IConfigRepository _configRepository;
    private readonly IMapper _mapper;

    public UpdateConfigHandler(IEnterpriseRepository enterpriseRepository, IConfigRepository configRepository, IMapper mapper)
    {
        _enterpriseRepository = enterpriseRepository;
        _configRepository = configRepository;
        _mapper = mapper;
    }
    public async Task<GetConfigDto> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
    {
        var enterprise = await _enterpriseRepository.GetEnterpriseByUser(request.UserId);
        if (enterprise is null)
            throw new DbException();

        var config = await _configRepository.GetConfigByEnterprise(enterprise.Id);
        if (config is null)
            throw new DbException();

        var updatedConfig = await _configRepository.UpdateConfig(config);
        if (updatedConfig is null)
            throw new DbException();

        return _mapper.Map<GetConfigDto>(updatedConfig);

    }
}