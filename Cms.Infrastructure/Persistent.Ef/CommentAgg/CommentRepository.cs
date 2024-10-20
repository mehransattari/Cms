using Cms.Infrastructure._Utilities;
using Cms.Infrastructure.Persistent.Ef;
using Cms.Domain.CommentAgg;

namespace Cms.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(CmsContext context) : base(context)
    {
    }
}