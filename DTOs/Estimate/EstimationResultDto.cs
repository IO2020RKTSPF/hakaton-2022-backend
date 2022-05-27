using hakaton_2022_backend.DTOs.Config;

namespace hakaton_2022_backend.DTOs.Estimate;

public class EstimationResultDto
{
    public ParametersDto Parameters { get; set; }
    public int Result { get; set; }
    public int UserResult { get; set; }
}