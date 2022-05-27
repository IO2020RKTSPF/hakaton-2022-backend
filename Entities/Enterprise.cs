namespace hakaton_2022_backend.Entities;

public class Enterprise
{
    public string Name { get; set; }
    public User Admin { get; set; }
    public ICollection<User> Users { get; set; }
    public Config Config { get; set; }
}