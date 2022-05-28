using hakaton_2022_backend.Core.Entities;
using hakaton_2022_backend.Infrastructure.Data;

namespace hakaton_2022_backend.Infrastructure.Repositories;

public interface IParametersRepository
{
    public Task<Parameters> AddParameters(Parameters parameters);
}

public class ParametersRepository : Repository<Parameters>, IParametersRepository
{
    public ParametersRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Parameters> AddParameters(Parameters parameters)
    {
        return await base.AddAsync(parameters);
    }
}