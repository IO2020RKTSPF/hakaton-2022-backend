using AutoMapper;
using hakaton_2022_backend.Application.DTOs.Config;
using hakaton_2022_backend.Core.Entities;

namespace hakaton_2022_backend.Infrastructure.Profiles;

public class ConfigProfile : Profile
{
    public ConfigProfile()
    {
        CreateMap<Config, GetConfigDto>().ReverseMap();
    }
}