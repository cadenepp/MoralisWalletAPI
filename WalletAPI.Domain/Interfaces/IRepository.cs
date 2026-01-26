namespace WalletAPI.Domain.Interfaces;

public interface IRepository <T> where T:class
{
    Task AddAsync(T entity);
    Task<T[]> GetAllAsync();
    Task<T> GetByIdAsync();
    Task SaveChangesAsync();
}