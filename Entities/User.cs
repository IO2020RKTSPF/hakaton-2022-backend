namespace hakaton_2022_backend.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public ICollection<Estimation> Estimations { get; set; }
    public Enterprise Enterprise { get; set; }
}