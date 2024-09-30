using Microsoft.EntityFrameworkCore;
using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.IAM.Domain.Repositories;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProductAPI.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}