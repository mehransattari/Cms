using Common.Application;
using Common.Domain.ValueObjects;

namespace Cms.Application.Categories.Create
{
    public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand<long>;
}