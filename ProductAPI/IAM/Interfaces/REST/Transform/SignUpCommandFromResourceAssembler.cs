using ProductAPI.IAM.Domain.Model.Commands;
using ProductAPI.IAM.Interfaces.REST.Resources;

namespace ProductAPI.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}