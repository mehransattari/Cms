using Cms.Domain.UserAgg.Repository;
using Cms.Domain.UserAgg.Services;

namespace Cms.Application.Users;

public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _userRepository;

    public UserDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool IsEmailExist(string email)
    {
        var result = _userRepository.Exists(x => x.Email == email);
        return result;
    }

    public bool PhoneNumberIsExist(string phoneNumber)
    {
        var result = _userRepository.Exists(x => x.PhoneNumber == phoneNumber);
        return result;
    }
}