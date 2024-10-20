using Cms.Query.Roles.DTOs;
using Common.Query;

namespace Cms.Query.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;