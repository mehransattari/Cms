using Common.Application;

namespace Cms.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(long UserId, long ItemId) : IBaseCommand;
}