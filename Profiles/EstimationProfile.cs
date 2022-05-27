using AutoMapper;
using hakaton_2022_backend.DTOs.Estimate;
using hakaton_2022_backend.Entities;

namespace hakaton_2022_backend.Profiles;

public class EstimationProfile : Profile
{
    public EstimationProfile()
    {
        CreateMap<Estimation, EstimationResultDto>();
    }
}