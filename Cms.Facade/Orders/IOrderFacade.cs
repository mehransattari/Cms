using Common.Application;
using Cms.Application.Orders.AddItem;
using Cms.Application.Orders.Checkout;
using Cms.Application.Orders.DecreaseItemCount;
using Cms.Application.Orders.IncreaseItemCount;
using Cms.Application.Orders.RemoveItem;
using Cms.Query.Orders.DTOs;

namespace Cms.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
    Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
    Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);



    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
}