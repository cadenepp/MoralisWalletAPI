using WalletAPI.Domain.Interfaces;
using WalletAPI.Infrastructure.Repositories;

namespace WalletAPI.Application.Services;

public class UserService : UserRepository
{
    private readonly UserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
         _userRepository = userRepository;
    }

    // TODO: Crud Logic for Creating a User - Arun
}