using Cms.Query.Categories.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Categories.GetById;

internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly CmsContext _context;

    public GetCategoryByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories
            .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
        return model.Map();
    }
}