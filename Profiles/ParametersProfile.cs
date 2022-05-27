using AutoMapper;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Entities;

namespace hakaton_2022_backend.Profiles;

public class ParametersProfile : Profile
{
    public ParametersProfile()
    {
        CreateMap<Parameters, ParametersDto>().ReverseMap();
    }
}