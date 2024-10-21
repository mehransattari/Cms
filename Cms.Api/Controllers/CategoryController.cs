using Cms.Application.Categories.AddChild;
using Cms.Application.Categories.Create;
using Cms.Application.Categories.Edit;
using Cms.Facade.Categories;
using Cms.Query.Categories.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cms.Api.Controllers;

public class CategoryController : ApiController
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _categoryFacade.GetCategories();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
    {
        var result = await _categoryFacade.GetCategoryById(id);
        return QueryResult(result);
    }

    [HttpGet("getChild/{parentId}")]
    public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
    {
        var result = await _categoryFacade.GetCategoriesByParentId(parentId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.Create(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);
    }

    [HttpPost("AddChild")]
    public async Task<ApiResult<long>> CreateCategory(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);
    }

    [HttpPut]
    public async Task<ApiResult<long>> EditCategory(EditCategoryCommand command)
    {
        var result = await _categoryFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpDelete("{categoryId}")]
    public async Task<ApiResult> RemoveCategory(long categoryId)
    {
        var result = await _categoryFacade.Remove(categoryId);
        return CommandResult(result);
    }
}
