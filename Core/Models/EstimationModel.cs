using Microsoft.ML.Data;

namespace hakaton_2022_backend.Core.Models;

public class EstimationModel
{
    [LoadColumn(0)]
    public float LinesOfCode { get; set; }
    
    [LoadColumn(1)]
    public float CodeFamiliarity { get; set; }
    
    [LoadColumn(2)]
    public float ExperienceLevel { get; set; }
    
    [LoadColumn(3)]
    public float ProjectScale { get; set; }
    
    [LoadColumn(4)]
    public float TaskKnowledge { get; set; }
    
    [LoadColumn(5)]
    public float DesiredCodeQuality { get; set; }

    [LoadColumn(6)]
    public float UserResult { get; set; } 
}