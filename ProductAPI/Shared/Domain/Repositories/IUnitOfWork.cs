namespace ProductAPI.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}