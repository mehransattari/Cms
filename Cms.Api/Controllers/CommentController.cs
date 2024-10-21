using Cms.Application.Comments.ChangeStatus;
using Cms.Application.Comments.Create;
using Cms.Application.Comments.Edit;
using Cms.Facade.Comments;
using Cms.Query.Comments.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class CommentController : ApiController
{
    private readonly ICommentFacade _commentFacade;
    public CommentController(ICommentFacade commentFacade)
    {
        _commentFacade = commentFacade;
    }
    [HttpGet]
    public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter([FromQuery] CommentFilterParams filterParams)
    {
        var result = await _commentFacade.GetCommentsByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("{commentId}")]
    public async Task<ApiResult<CommentDto?>> GetCommentByFilter(long commentId)
    {
        var result = await _commentFacade.GetCommentById(commentId);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> GetCommentByFilter(CreateCommentCommand command)
    {
        var result = await _commentFacade.CreateComment(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _commentFacade.EditComment(command);
        return CommandResult(result);
    }
    [HttpPut("changeStatus")]
    public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
    {
        var result = await _commentFacade.ChangeStatus(command);
        return CommandResult(result);
    }
}