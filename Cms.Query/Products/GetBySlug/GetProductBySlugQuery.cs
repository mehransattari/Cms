using Cms.Query.Products.DTOs;
using Common.Query;

namespace Cms.Query.Products.GetBySlug;

public class GetProductBySlugQuery : IQuery<ProductDto?>
{
    public GetProductBySlugQuery(string slug)
    {
        Slug = slug;
    }

    public string Slug { get; private set; }
}