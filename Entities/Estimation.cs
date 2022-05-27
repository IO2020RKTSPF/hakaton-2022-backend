namespace hakaton_2022_backend.Entities;

public class Estimation
{
    public int Id { get; set; }
    public Config Config { get; set; }
    public int Result { get; set; }
    public User User { get; set; }
    public int UserResult { get; set; } = -1;
}