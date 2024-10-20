using Cms.Query.Categories.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Categories.GetByParentId;

internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildCategoryDto>>
{
    private readonly CmsContext _context;

    public GetCategoryByParentIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);

        return result.MapChildren();
    }
}