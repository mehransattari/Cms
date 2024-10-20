using Common.Query;
using Cms.Domain.RoleAgg;
using Cms.Domain.RoleAgg.Enums;

namespace Cms.Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}