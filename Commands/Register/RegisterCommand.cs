using hakaton_2022_backend.DTOs.Auth;
using MediatR;

namespace hakaton_2022_backend.Commands.Register;

public class RegisterCommand : IRequest<RegisterResponseDto>
{
    public RegisterCommand(string organizationName, string username, string password, string email)
    {
        OrganizationName = organizationName;
        Username = username;
        Password = password;
        Email = email;
    }

    public string OrganizationName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}