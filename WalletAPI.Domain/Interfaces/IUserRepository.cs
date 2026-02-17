using WalletAPI.Domain.Models;

namespace WalletAPI.Domain.Interfaces;

public interface IUserRepository <T> where T : User
{
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<object> GetByIdAsync(int userid, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}