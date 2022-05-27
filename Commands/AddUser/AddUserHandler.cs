using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Exceptions;
using MediatR;

namespace hakaton_2022_backend.Commands.AddUser;

public class AddUserHandler : IRequestHandler<AddUserCommand, bool>
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IEnterpriseRepository enterpriseRepository, IUserRepository userRepository)
    {
        _enterpriseRepository = enterpriseRepository;
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var enterprise = await _enterpriseRepository.GetEnterpriseByUser(request.OwnerId);
        if (enterprise is null)
            throw new DbException();

        var userInDb = await _userRepository.GetByPredicate(x => x.Username == request.Username);
        if (userInDb is not null)
            throw new UserAlreadyExistsException();

        var newUser = new User()
        {
            Email = request.Email,
            Password = request.Password,
            Username = request.Username,
            Enterprise = enterprise
        };

        var addedUser = await _userRepository.AddUser(newUser);
        if (addedUser is null)
            throw new DbException();

        return true;
    }
}