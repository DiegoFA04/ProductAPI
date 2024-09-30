using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.IAM.Domain.Model.Commands;

namespace ProductAPI.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}