using Cms.Query.Products.DTOs;
using Common.Query;

namespace Cms.Query.Products.GetById;

public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto?>;