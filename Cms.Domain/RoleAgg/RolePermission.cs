using Cms.Domain.RoleAgg.Enums;
using Common.Domain;

namespace Cms.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public RolePermission(Permission permission)
        {
            Permission = permission;
        }

        public long RoleId { get; internal set; }
        public Permission Permission { get; private set; }
    }
}
