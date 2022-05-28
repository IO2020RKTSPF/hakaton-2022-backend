namespace hakaton_2022_backend.Core.Entities;

public class Enterprise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public User Admin { get; set; }
    public ICollection<User> Users { get; set; }
    public Config Config { get; set; }
}