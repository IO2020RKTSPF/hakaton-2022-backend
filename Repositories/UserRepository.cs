using System.Linq.Expressions;
using hakaton_2022_backend.Data;
using hakaton_2022_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace BitadAPI.Repositories;

public interface IUserRepository
{
    public Task<ICollection<User>> GetAll();
    public Task<User?> GetUserById(int id);
    public Task<User?> AddUser(User user);
    public Task<User?> GetByPredicate(Expression<Func<User, bool>> predicate);
}

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }


    public new async Task<ICollection<User>> GetAll()
    {
        return await base.GetAll().Include(x=>x.Enterprise).ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await base.GetAll().Include(x=>x.Enterprise).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> AddUser(User user)
    {
        return await base.AddAsync(user);
    }

    public async Task<User?> GetByPredicate(Expression<Func<User, bool>> predicate)
    {
        return await base.GetAll().Include(x=>x.Enterprise).FirstOrDefaultAsync(predicate);
    }
}