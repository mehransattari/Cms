using Cms.Query.Categories.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Categories.GetList;

internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly CmsContext _context;

    public GetCategoryListQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.Include(x=>x.Childs)
                                             .ThenInclude(x=>x.Childs)
                                             .OrderByDescending(d => d.Id)
                                             .ToListAsync(cancellationToken);
        return model.Map();
    }
}