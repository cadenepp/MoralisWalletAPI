using Microsoft.EntityFrameworkCore.Infrastructure;
using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
using WalletAPI.Infrastructure.Data;

namespace WalletAPI.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(WalletDbContext db) : base(db)
    {
        
    }
}