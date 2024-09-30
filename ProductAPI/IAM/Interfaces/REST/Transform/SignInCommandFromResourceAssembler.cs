using ProductAPI.IAM.Domain.Model.Commands;
using ProductAPI.IAM.Interfaces.REST.Resources;

namespace ProductAPI.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}