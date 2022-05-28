using hakaton_2022_backend.Application.DTOs.Config;
using MediatR;

namespace hakaton_2022_backend.Application.Queries.GetConfig;

public class GetConfigQuery : IRequest<GetConfigDto>
{
    public int UserId { get; set; }
}