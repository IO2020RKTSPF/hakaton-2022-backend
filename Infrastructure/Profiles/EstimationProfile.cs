using AutoMapper;
using hakaton_2022_backend.Application.DTOs.Estimate;
using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Core.Models;

namespace hakaton_2022_backend.Infrastructure.Profiles;

public class EstimationProfile : Profile
{
    public EstimationProfile()
    {
        CreateMap<Estimation, EstimationResultDto>().ReverseMap();
        CreateMap<Estimation, EstimationModel>()
            .ForMember(x=>x.CodeFamiliarity, d => d.MapFrom(v=>v.Parameters.CodeFamiliarity))
            .ForMember(x=>x.ExperienceLevel, d => d.MapFrom(v=>v.Parameters.ExperienceLevel))
            .ForMember(x=>x.ProjectScale, d => d.MapFrom(v=>v.Parameters.ProjectScale))
            .ForMember(x=>x.TaskKnowledge, d => d.MapFrom(v=>v.Parameters.TaskKnowledge))
            .ForMember(x=>x.UserResult, d => d.MapFrom(v=>v.UserResult))
            .ForMember(x=>x.DesiredCodeQuality, d => d.MapFrom(v=>v.Parameters.DesiredCodeQuality))
            .ForMember(x=>x.LinesOfCode, d => d.MapFrom(v=>v.Parameters.LinesOfCode));







    }
}