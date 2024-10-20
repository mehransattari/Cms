using Common.Application;

namespace Cms.Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}