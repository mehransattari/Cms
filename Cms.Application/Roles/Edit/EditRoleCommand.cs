using Common.Application;
using Cms.Domain.RoleAgg;
using Cms.Domain.RoleAgg.Enums;

namespace Cms.Application.Roles.Edit;

public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;