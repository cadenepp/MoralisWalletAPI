using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;
namespace WalletAPI.Application.Services;

public class CreateUserService
{
    private readonly UserRepository _userRepository;
    public CreateUserService(UserRepository userRepository)
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

        var userServices  = await _userRepository.GetByIdAsync(userid, cancellationToken);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<object> GetUserByIdAsync( int userid, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userid, cancellationToken);
        return user;
    }
        
    // TODO: Crud Logic for Creating a User - Arun
}