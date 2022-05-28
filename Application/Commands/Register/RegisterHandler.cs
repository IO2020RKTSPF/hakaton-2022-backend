using hakaton_2022_backend.Application.Commands.Login;
using hakaton_2022_backend.Application.DTOs.Auth;
using hakaton_2022_backend.Application.Exceptions;
using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Repositories;
using MediatR;

namespace hakaton_2022_backend.Application.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IMediator _mediator;
    private readonly IConfigRepository _configRepository;

    public RegisterHandler(IUserRepository userRepository, IEnterpriseRepository enterpriseRepository, IMediator mediator, IConfigRepository configRepository)
    {
        _userRepository = userRepository;
        _enterpriseRepository = enterpriseRepository;
        _mediator = mediator;
        _configRepository = configRepository;
    }
    public async Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _enterpriseRepository.ExistsByName(request.OrganizationName))
            throw new EnterpriseAlreadyExistsException();
        //TODO: HASH PASSWORD
        var user = await _userRepository.GetByPredicate(x => x.Email == request.Email | x.Username == request.Username);
        if (user is not null)
            throw new UserAlreadyExistsException();

        var newUser = new User()
        {
            Email = request.Email,
            Password = request.Password,
            Username = request.Username,
        };
        var addResponse = await _userRepository.AddUser(newUser);
        if (addResponse is null)
            throw new DbException();

        var enterprise = new Enterprise()
        {
            Admin = addResponse,
            Name = request.OrganizationName,
            Users = new List<User>(){addResponse}
        };

        //TODO: SET DEFAULT VALUES
        var config = new Config()
        {
            Enterprise = enterprise,
            MinutesQuality = 30,
            MinutesPerExperience = 30,
            MinutesPerLines = 1,
            MinutesPerCodeFamiliarity = 30,
            MinutesPerProjectScale = 30,
            MinutesPerTaskKnowledge = 30,
            AiUseOnlyInternalEstimations = false
        };

        var addedConfig = await _configRepository.AddConfig(config);
        if (addedConfig is null)
            throw new DbException();

        var token = await _mediator.Send(new LoginCommand(request.Username, request.Password));

        return new RegisterResponseDto() {Token = token.Token};

    }
}