using Cms.Domain.CategoryAgg;
using Cms.Domain.ProductAgg.Repository;
using Cms.Domain.ProductAgg.Services;

namespace Cms.Application.Products;

public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _productRepository;
    public ProductDomainService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }    

    public bool SlugIsExist(string slug)
    {
        var result = _productRepository.Exists(x => x.Slug == slug);
        return result;
    }
}