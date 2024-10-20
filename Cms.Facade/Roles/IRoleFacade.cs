using Common.Application;
using Cms.Application.Roles.Create;
using Cms.Application.Roles.Edit;
using Cms.Query.Roles.DTOs;

namespace Cms.Facade.Roles;

public interface IRoleFacade
{
    Task<OperationResult> CreateRole(CreateRoleCommand command);
    Task<OperationResult> EditRole(EditRoleCommand command);

    Task<RoleDto?> GetRoleById(long roleId);
    Task<List<RoleDto>> GetRoles();
}