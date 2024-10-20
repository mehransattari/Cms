using Cms.Query.Products;
using Cms.Query.Products.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Products.GetById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly CmsContext _context;

    public GetProductByIdQueryHandler(CmsContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(f => f.Id == request.ProductId, cancellationToken);

        var model = product.Map();
        if (model == null)
            return null;
        await model.SetCategories(_context);
        return model;
    }
}