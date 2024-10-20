using Common.Application;
using MediatR;
using Cms.Application.Comments.ChangeStatus;
using Cms.Application.Comments.Create;
using Cms.Application.Comments.Edit;
using Cms.Query.Comments.DTOs;
using Cms.Query.Comments.GetByFilter;
using Cms.Query.Comments.GetById;

namespace Cms.Facade.Comments;

internal class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;

    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CreateComment(CreateCommentCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> EditComment(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentDto?> GetCommentById(long id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));
    }

    public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
    }
}