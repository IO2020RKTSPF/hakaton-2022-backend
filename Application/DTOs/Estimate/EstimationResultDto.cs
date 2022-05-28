namespace hakaton_2022_backend.Application.DTOs.Estimate;

public class EstimationResultDto
{
    public string Name { get; set; }
    public ParametersDto Parameters { get; set; }
    public int Result { get; set; }
    public int UserResult { get; set; }
}