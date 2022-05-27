using BitadAPI.Repositories;
using hakaton_2022_backend.Commands.Login;
using hakaton_2022_backend.DTOs.Auth;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Exceptions;
using MediatR;

namespace hakaton_2022_backend.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IMediator _mediator;

    public RegisterHandler(IUserRepository userRepository, IEnterpriseRepository enterpriseRepository, IMediator mediator)
    {
        _userRepository = userRepository;
        _enterpriseRepository = enterpriseRepository;
        _mediator = mediator;
    }
    public async Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _enterpriseRepository.ExistsByName(request.OrganizationName))
            throw new EnterpriseAlreadyExistsException();

        var user = await _userRepository.GetByPredicate(x => x.Email == request.Email | x.Username == request.Username);
        if (user is not null)
            throw new UserAlreadyExistsException();

        var newUser = new User()
        {
            Email = request.Email,
            Password = request.Password,
            Username = request.Username
        };
        var addResponse = await _userRepository.AddUser(newUser);
        if (addResponse is null)
            throw new DbException();

        var token = await _mediator.Send(new LoginCommand(request.Username, request.Password));

        return new RegisterResponseDto() {Token = token.Token};

    }
}