using hakaton_2022_backend.DTOs.Config;
using MediatR;

namespace hakaton_2022_backend.Queries.GetConfig;

public class GetConfigQuery : IRequest<GetConfigDto>
{
    public int UserId { get; set; }
}