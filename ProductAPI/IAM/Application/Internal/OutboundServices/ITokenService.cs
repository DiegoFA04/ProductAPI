using ProductAPI.IAM.Domain.Model.Aggregates;

namespace ProductAPI.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}