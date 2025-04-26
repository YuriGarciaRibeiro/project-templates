namespace Core.Interfaces;

using Core.Entities;

public interface IUserRepository
{
    Task AddAsync(User usuario);
}
