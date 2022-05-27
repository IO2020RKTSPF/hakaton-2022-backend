using hakaton_2022_backend.Data;

namespace BitadAPI.Repositories
{
    public interface IRepository<TEntity>
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;

        public Repository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}