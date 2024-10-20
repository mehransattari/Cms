using Common.Application;
using MediatR;
using Cms.Application.Products.AddImage;
using Cms.Application.Products.Create;
using Cms.Application.Products.Edit;
using Cms.Application.Products.RemoveImage;
using Cms.Query.Products.DTOs;
using Cms.Query.Products.GetByFilter;
using Cms.Query.Products.GetById;
using Cms.Query.Products.GetBySlug;

namespace Cms.Facade.Products;

internal class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateProduct(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditProduct(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        return await _mediator.Send(command); ;
    }

    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProductDto?> GetProductById(long productId)
    {
        return await _mediator.Send(new GetProductByIdQuery(productId));
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
        return await _mediator.Send(new GetProductBySlugQuery(slug));
    }
    public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
    {
        return await _mediator.Send(new GetProductsByFilterQuery(filterParams));
    }
}