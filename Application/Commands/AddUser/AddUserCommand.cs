using MediatR;

namespace hakaton_2022_backend.Application.Commands.AddUser;

public class AddUserCommand : IRequest<bool>
{
    public int OwnerId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}