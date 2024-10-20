using Common.Application;
using Cms.Application.Products.AddImage;
using Cms.Application.Products.Create;
using Cms.Application.Products.Edit;
using Cms.Application.Products.RemoveImage;
using Cms.Query.Products.DTOs;

namespace Cms.Facade.Products;

public interface IProductFacade
{
    Task<OperationResult> CreateProduct(CreateProductCommand command);
    Task<OperationResult> EditProduct(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductDto?> GetProductById(long productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
}