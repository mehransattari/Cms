using Common.Application;


namespace Cms.Application.Categories.Remove;

public record RemoveCategoryCommand(long CategoryId) : IBaseCommand;
