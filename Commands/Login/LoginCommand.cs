using hakaton_2022_backend.DTOs.Auth;
using MediatR;

namespace hakaton_2022_backend.Commands.Login;

public class LoginCommand : IRequest<LoginResponseDto>
{
    public LoginCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; set; }
    public string Password { get; set; }
}