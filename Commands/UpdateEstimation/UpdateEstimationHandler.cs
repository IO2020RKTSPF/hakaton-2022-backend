using AutoMapper;
using BitadAPI.Repositories;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Exceptions;
using MediatR;

namespace hakaton_2022_backend.Commands.UpdateEstimation;

public class UpdateEstimationHandler : IRequestHandler<UpdateEstimationCommand, GetEstimationDto>
{
    private readonly IEstimationRepository _estimationRepository;
    private readonly IMapper _mapper;

    public UpdateEstimationHandler(IEstimationRepository estimationRepository, IMapper mapper)
    {
        _estimationRepository = estimationRepository;
        _mapper = mapper;
    }
    public async Task<GetEstimationDto> Handle(UpdateEstimationCommand request, CancellationToken cancellationToken)
    {
        var estimation = await _estimationRepository.GetEstimation(request.Id);
        if (estimation is null)
            throw new DbException();

        estimation.UserResult = request.ActualValue;

        var updatedEstimation = await _estimationRepository.UpdateEstimation(estimation);
        if (updatedEstimation is null)
            throw new DbException();

        return _mapper.Map<GetEstimationDto>(estimation);
    }
}