using Microsoft.ML.Data;

namespace hakaton_2022_backend.Core.Models;

public class EstimationModelPrediction
{
    [ColumnName("Score")]
    public float UserResult;
}