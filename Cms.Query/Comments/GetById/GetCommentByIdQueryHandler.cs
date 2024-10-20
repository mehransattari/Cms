using Cms.Query.Comments.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Comments.GetById;

internal class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly CmsContext _context;

    public GetCommentByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId, cancellationToken: cancellationToken);

        return comment.Map();
    }
}