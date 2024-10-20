using Common.Application;

namespace Cms.Application.Orders.DecreaseItemCount;
public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;