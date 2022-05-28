using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hakaton_2022_backend.Infrastructure.Repositories;

public interface IEnterpriseRepository
{
    public Task<Enterprise?> GetById(int id);
    public Task<Enterprise?> CreateEnterprise(Enterprise enterprise);
    public Task<Enterprise?> GetEnterpriseByUser(int userId);
    public Task<bool> IsUserEnterpriseOwner(int userId, int enterpriseId);
    public Task<bool> ExistsByName(string name);
}

public class EnterpriseRepository : Repository<Enterprise>, IEnterpriseRepository
{
    public EnterpriseRepository(AppDbContext context) : base(context) { }

    public async Task<Enterprise?> GetById(int id)
    {
        return await base.GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Enterprise?> CreateEnterprise(Enterprise enterprise)
    {
        return await base.AddAsync(enterprise);
    }

    public async Task<Enterprise?> GetEnterpriseByUser(int userId)
    {
        return await base.GetAll().Include(x => x.Users).FirstOrDefaultAsync(x => x.Users.Any(y => y.Id == userId));
    }

    public async Task<bool> IsUserEnterpriseOwner(int userId, int enterpriseId)
    {
        var enterprise = await base.GetAll().Include(x => x.Admin).FirstOrDefaultAsync(x => x.Id == enterpriseId);
        if (enterprise is null) return false;
        return enterprise.Admin.Id == userId;
    }

    public async Task<bool> ExistsByName(string name)
    {
        return await GetAll().AnyAsync(x => x.Name == name);
    }
}