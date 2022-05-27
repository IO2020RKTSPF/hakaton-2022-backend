using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories;

public interface IEstimationRepository
{
    public Task<Estimation?> GetEstimation(int id);
    public Task<Estimation?> AddEstimation(Estimation estimation);
    public Task<ICollection<Estimation>> GetEstimationsForUser(int userId);
    public Task<Estimation?> UpdateEstimation(Estimation estimation);
}

public class EstimationRepository : Repository<Estimation>, IEstimationRepository
{
    public EstimationRepository(AppDbContext context) : base(context) { }
    public async Task<Estimation?> GetEstimation(int id)
    {
        return await base.GetAll().Include(x => x.Parameters).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Estimation?> AddEstimation(Estimation estimation)
    {
        return await base.AddAsync(estimation);
    }

    public async Task<ICollection<Estimation>> GetEstimationsForUser(int userId)
    {
        return await GetAll().Include(x => x.Parameters).Where(x => x.User.Id == userId).ToListAsync();
    }

    public async Task<Estimation?> UpdateEstimation(Estimation estimation)
    {
        return await UpdateAsync(estimation);
    }
}