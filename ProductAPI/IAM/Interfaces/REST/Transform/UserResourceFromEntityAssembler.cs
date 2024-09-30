using ProductAPI.IAM.Domain.Model.Aggregates;
using ProductAPI.IAM.Interfaces.REST.Resources;

namespace ProductAPI.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}