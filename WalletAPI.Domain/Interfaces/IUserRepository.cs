using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    

}