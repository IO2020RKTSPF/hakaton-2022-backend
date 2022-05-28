using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace hakaton_2022_backend.Infrastructure.Repositories;

public interface IConfigRepository
{
    public Task<Config?> AddConfig(Config config);
    public Task<Config?> GetConfigByEnterprise(int enterpriseId);
    public Task<Config?> UpdateConfig(Config config);

}

public class ConfigRepository : Repository<Config>, IConfigRepository
{
    public ConfigRepository(AppDbContext context) : base(context) { }


    public async Task<Config?> AddConfig(Config config)
    {
        return await base.AddAsync(config);
    }

    public async Task<Config?> GetConfigByEnterprise(int enterpriseId)
    {
        return await base.GetAll().Include(x => x.Enterprise).FirstOrDefaultAsync(x => x.Enterprise.Id == enterpriseId);
    }

    public async Task<Config?> UpdateConfig(Config config)
    {
        return await base.UpdateAsync(config);
    }
}