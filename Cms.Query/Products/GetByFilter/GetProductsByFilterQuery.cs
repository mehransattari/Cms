using Cms.Query.Products.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Cms.Query.Products.GetByFilter;

public class GetProductsByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductsByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
    }
}