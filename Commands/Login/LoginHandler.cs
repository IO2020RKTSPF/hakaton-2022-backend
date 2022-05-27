using BitadAPI.Repositories;
using hakaton_2022_backend.DTOs.Auth;
using hakaton_2022_backend.Exceptions;
using hakaton_2022_backend.Factories;
using MediatR;

namespace hakaton_2022_backend.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtFactory _jwtFactory;

    public LoginHandler(IUserRepository userRepository, IJwtFactory jwtFactory)
    {
        _userRepository = userRepository;
        _jwtFactory = jwtFactory;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByPredicate(x =>
            x.Username == request.Username || request.Password == x.Password);
        if (user is null)
            throw new IncorrentCredentialsException();

        var token = await _jwtFactory.Generate(user);
        return new LoginResponseDto() {Token = token};
    }
}