using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;

namespace BitadAPI.Repositories;

public interface IEstimationRepository
{
    public Task<Estimation> GetEstimation();
    public Task<Estimation> AddEstimation();
}

public class EstimationRepository : Repository<Estimation>, IEstimationRepository
{
    public EstimationRepository(AppDbContext context) : base(context) { }
    public Task<Estimation> GetEstimation()
    {
        throw new NotImplementedException();
    }

    public Task<Estimation> AddEstimation()
    {
        throw new NotImplementedException();
    }
}