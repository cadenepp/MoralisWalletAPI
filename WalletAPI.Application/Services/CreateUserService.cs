using WalletAPI.Domain.Interfaces;
using WalletAPI.Domain.Models;

namespace WalletAPI.Application.Services;

public class CreateUserService
{
    private readonly IUserRepository<User> _userRepository;
    public CreateUserService(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
        
    }
    public async Task CreateAsync(string username, string password, int age, string email, string reason,
        CancellationToken cancellationToken = default)
    {
        var userService = new User
        {
            Username = username,
            Password = password,
            Age = age,
            Email = email,
            Reason = reason,
        };
        await _userRepository.AddAsync(userService,cancellationToken);

        await _userRepository.SaveChangesAsync(); 
    }
    public async Task DeleteAsync( int userid, CancellationToken cancellationToken = default)
    {

        var userServices  = await _userRepository.GetByIdAsync(userid, cancellationToken);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<object> GetUserByIdAsync( int userid, CancellationToken cancellationToken = default)
    {
        var userService = await _userRepository.GetByIdAsync(userid, cancellationToken);
        return userService;
    }
        
    // TODO: Crud Logic for Creating a User - Arun
}