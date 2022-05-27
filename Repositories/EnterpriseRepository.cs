using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;

namespace BitadAPI.Repositories;

public interface IEnterpriseRepository
{
    
}

public class EnterpriseRepository : Repository<Enterprise>, IEnterpriseRepository
{
    public EnterpriseRepository(AppDbContext context) : base(context) { }
    
}