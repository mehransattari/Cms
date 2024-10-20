using Common.Application;
using Cms.Application.Comments.ChangeStatus;
using Cms.Application.Comments.Create;
using Cms.Application.Comments.Edit;
using Cms.Query.Comments.DTOs;

namespace Cms.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);


    Task<CommentDto?> GetCommentById(long id);
    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
}