using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.IAM.Domain.Model.Queries;

namespace ProductAPI.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}