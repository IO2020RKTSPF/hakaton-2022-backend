using hakaton_2022_backend.Core.Models;

namespace hakaton_2022_backend.Core.Services;

public interface IEstimationMachineLearningService
{
    public Task<int> Calculate(EstimationModel estimationModel, bool useOnlyInternal);
}