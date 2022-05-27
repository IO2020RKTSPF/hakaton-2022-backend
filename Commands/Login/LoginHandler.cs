using hakaton_2022_backend.DTOs.Auth;
using MediatR;

namespace hakaton_2022_backend.Commands.Login;

public class LoginHandler : RequestHandler<LoginCommand, LoginResponseDto>
{
    protected override LoginResponseDto Handle(LoginCommand request)
    {
        throw new NotImplementedException();
    }
}