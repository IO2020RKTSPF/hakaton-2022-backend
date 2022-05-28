using Microsoft.ML.Data;

namespace hakaton_2022_backend.Models;

public class EstimationModelPrediction
{
    [ColumnName("Score")]
    public float UserResult;
}