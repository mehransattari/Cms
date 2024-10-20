using Cms.Query.Comments.DTOs;
using Common.Query;

namespace Cms.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
{
    public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
    {
    }
}