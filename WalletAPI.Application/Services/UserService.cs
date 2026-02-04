using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
using WalletAPI.Infrastructure.Data;
using WalletAPI.Infrastructure.Repositories;

namespace WalletAPI.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
         _userRepository = userRepository;
        
    }
    public async Task CreateAsync(string username, string password, int UserId, int age, string email, string reason, CancellationToken cancellationToken = default)
    {
        
    }
    // TODO: Crud Logic for Creating a User - Arun
}