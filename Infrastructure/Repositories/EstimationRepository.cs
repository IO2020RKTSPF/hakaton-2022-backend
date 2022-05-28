using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hakaton_2022_backend.Infrastructure.Repositories;

public interface IEstimationRepository
{
    public Task<Estimation?> GetEstimation(int id);
    public Task<Estimation?> AddEstimation(Estimation estimation);
    public Task<ICollection<Estimation>> GetEstimationsForUser(int userId);
    public Task<Estimation?> UpdateEstimation(Estimation estimation);
    public Task<IEnumerable<Estimation>> GetAllEstimations();
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
        return await base.GetAll().Include(x => x.Parameters).Where(x => x.User.Id == userId).ToListAsync();
    }

    public async Task<Estimation?> UpdateEstimation(Estimation estimation)
    {
        return await UpdateAsync(estimation);
    }

    public async Task<IEnumerable<Estimation>> GetAllEstimations()
    {
        return await base.GetAll().Include(x=>x.Parameters).ToListAsync();
    }
}