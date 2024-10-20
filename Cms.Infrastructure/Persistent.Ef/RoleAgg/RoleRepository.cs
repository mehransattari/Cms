using Cms.Infrastructure._Utilities;
using Cms.Infrastructure.Persistent.Ef;
using Common.Application.Validation;
using Cms.Domain.RoleAgg;
using Cms.Domain.RoleAgg.Repository;

namespace Cms.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(CmsContext context) : base(context)
    {
    }
}