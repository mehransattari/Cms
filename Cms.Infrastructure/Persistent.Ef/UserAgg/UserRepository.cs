using Cms.Infrastructure._Utilities;
using Cms.Domain.UserAgg;
using Cms.Domain.UserAgg.Repository;

namespace Cms.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CmsContext context) : base(context)
        {
        }
    }
}