using hakaton_2022_backend.DTOs.Auth;
using MediatR;

namespace hakaton_2022_backend.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResponseDto>
{
    public Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}