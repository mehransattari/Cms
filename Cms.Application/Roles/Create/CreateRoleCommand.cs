using Common.Application;
using Cms.Domain.RoleAgg;
using Cms.Domain.RoleAgg.Enums;

namespace Cms.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;