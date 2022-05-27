namespace hakaton_2022_backend.Entities;

public class Config
{
    public int Id { get; set; }
    public int MinutesPerLines { get; set; }
    public int MinutesPerCodeFamiliarity { get; set; }
    public int MinutesPerExperience { get; set; }
    public int MinutesPerProjectScale { get; set; }
    public int MinutesPerTaskKnowledge { get; set; }
    public int MinutesQuality { get; set; }
    public Enterprise Enterprise { get; set; }
    public int EnterpriseId { get; set; }
}