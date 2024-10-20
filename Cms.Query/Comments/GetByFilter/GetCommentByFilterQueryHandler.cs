﻿using Cms.Query.Comments.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Comments.GetByFilter;

internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly CmsContext _context;

    public GetCommentByFilterQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var result = _context.Comments.OrderByDescending(d => d.CreationDate).AsQueryable();

        if (@params.CommentStatus != null)
            result = result.Where(r => r.Status == @params.CommentStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);



        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(comment => comment.MapFilterComment())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}