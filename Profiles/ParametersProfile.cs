using AutoMapper;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Models;

namespace hakaton_2022_backend.Profiles;

public class ParametersProfile : Profile
{
    public ParametersProfile()
    {
        CreateMap<Parameters, ParametersDto>().ReverseMap();
        CreateMap<Parameters, EstimationModel>()
            .ForMember(x=>x.CodeFamiliarity, d => d.MapFrom(v=>v.CodeFamiliarity))
            .ForMember(x=>x.ExperienceLevel, d => d.MapFrom(v=>v.ExperienceLevel))
            .ForMember(x=>x.ProjectScale, d => d.MapFrom(v=>v.ProjectScale))
            .ForMember(x=>x.TaskKnowledge, d => d.MapFrom(v=>v.TaskKnowledge))
            .ForMember(x=>x.UserResult, d => d.MapFrom(v=> 0))
            .ForMember(x=>x.DesiredCodeQuality, d => d.MapFrom(v=>v.DesiredCodeQuality))
            .ForMember(x=>x.LinesOfCode, d => d.MapFrom(v=>v.LinesOfCode));
    }
}