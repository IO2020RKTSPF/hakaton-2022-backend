using AutoMapper;
using hakaton_2022_backend.DTOs.Config;
using hakaton_2022_backend.Entities;

namespace hakaton_2022_backend.Profiles;

public class ConfigProfile : Profile
{
    public ConfigProfile()
    {
        CreateMap<Config, GetConfigDto>().ReverseMap();
    }
}