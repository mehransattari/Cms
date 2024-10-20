using Cms.Query.Comments.DTOs;
using Common.Query;

namespace Cms.Query.Comments.GetById;

public record GetCommentByIdQuery(long CommentId) : IQuery<CommentDto?>;