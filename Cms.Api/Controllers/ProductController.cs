using Cms.Application.Products.AddImage;
using Cms.Application.Products.Create;
using Cms.Application.Products.Edit;
using Cms.Application.Products.RemoveImage;
using Cms.Facade.Products;
using Cms.Query.Products.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class ProductController : ApiController
{
    private IProductFacade _productFacade;
    public ProductController(IProductFacade productFacade)
    {
        _productFacade = productFacade;
    }

    [HttpGet]
    public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
    {
        return QueryResult(await _productFacade.GetProductsByFilter(filterParams));
    }

    [HttpGet("{productId}")]
    public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
    {
        var product = await _productFacade.GetProductById(productId);
        return QueryResult(product);
    }

    [HttpGet("{slug}")]
    public async Task<ApiResult<ProductDto?>> GetProductById(string slug)
    {
        var product = await _productFacade.GetProductBySlug(slug);
        return QueryResult(product);
    }

    [HttpPost]
    public async Task<ApiResult> CreateProduct([FromForm] CreateProductCommand command)
    {
        var result = await _productFacade.CreateProduct(command);
        return CommandResult(result);
    }

    [HttpPost("images")]
    public async Task<ApiResult> AddImage([FromForm] AddProductImageCommand command)
    {
        var result = await _productFacade.AddImage(command);
        return CommandResult(result);
    }

    [HttpDelete("images")]
    public async Task<ApiResult> RemoveImage(RemoveProductImageCommand command)
    {
        var result = await _productFacade.RemoveImage(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditProduct([FromForm] EditProductCommand command)
    {
        var result = await _productFacade.EditProduct(command);
        return CommandResult(result);
    }
}