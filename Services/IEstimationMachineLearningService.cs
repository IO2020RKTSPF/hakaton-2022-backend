using hakaton_2022_backend.Entities;
using hakaton_2022_backend.Models;

namespace hakaton_2022_backend.Services;

public interface IEstimationMachineLearningService
{
    public Task<int> Calculate(EstimationModel estimationModel);
}