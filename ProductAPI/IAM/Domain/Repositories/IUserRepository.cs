using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.Shared.Domain.Repositories;

namespace ProductAPI.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}