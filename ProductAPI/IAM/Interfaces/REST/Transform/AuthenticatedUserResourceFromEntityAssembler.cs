using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.IAM.Interfaces.REST.Resources;

namespace ProductAPI.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}