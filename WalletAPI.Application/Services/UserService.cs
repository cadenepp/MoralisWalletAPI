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

    public async Task CreateAsync(string username, string password, int age, string email, string reason,
        CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Username = username,
            Password = password,
            Age = age,
            Email = email,
            Reason = reason,
        };
        await _userRepository.AddAsync(user, cancellationToken);

        await _userRepository.SaveChangesAsync(); 
    }
    
    public async Task DeleteAsync( int userid, CancellationToken cancellationToken = default)
    {

        var user = await _userRepository.GetByIdAsync(userid, cancellationToken);
        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync();
    }
    
    // TODO: Crud Logic for Creating a User - Arun
}