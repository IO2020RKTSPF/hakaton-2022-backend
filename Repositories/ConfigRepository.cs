using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;

namespace BitadAPI.Repositories;

public interface IConfigRepository
{
    
}

public class ConfigRepository : Repository<Config>, IConfigRepository
{
    public ConfigRepository(AppDbContext context) : base(context) { }
    
    
}