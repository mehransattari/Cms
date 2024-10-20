using Common.Application;
using Cms.Application.Users.Create;
using Cms.Application.Users.Edit;
using Cms.Application.Users.Register;
using Cms.Query.Users.DTOs;

namespace Cms.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> CreateUser(CreateUserCommand command);

        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetUserById(long userId);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}