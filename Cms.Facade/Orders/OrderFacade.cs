using Common.Application;
using MediatR;
using Cms.Application.Orders.AddItem;
using Cms.Application.Orders.Checkout;
using Cms.Application.Orders.DecreaseItemCount;
using Cms.Application.Orders.IncreaseItemCount;
using Cms.Application.Orders.RemoveItem;
using Cms.Query.Orders.DTOs;
using Cms.Query.Orders.GetByFilter;
using Cms.Query.Orders.GetById;

namespace Cms.Facade.Orders;

internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OrderDto?> GetOrderById(long orderId)
    {
        return await _mediator.Send(new GetOrderByIdQuery(orderId));
    }

    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams)
    {
        return await _mediator.Send(new GetOrdersByFilterQuery(filterParams));
    }
}