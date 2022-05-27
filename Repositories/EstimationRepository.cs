using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;

namespace BitadAPI.Repositories;

public interface IEstimationRepository
{
    
}

public class EstimationRepository : Repository<Estimation>, IEstimationRepository
{
    public EstimationRepository(AppDbContext context) : base(context) { }
}