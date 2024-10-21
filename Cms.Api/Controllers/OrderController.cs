using Cms.Application.Orders.AddItem;
using Cms.Application.Orders.Checkout;
using Cms.Application.Orders.DecreaseItemCount;
using Cms.Application.Orders.IncreaseItemCount;
using Cms.Application.Orders.RemoveItem;
using Cms.Facade.Orders;
using Cms.Query.Orders.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers;
public class OrderController : ApiController
{
    private readonly IOrderFacade _orderFacade;
    public OrderController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }
    [HttpGet]
    public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
    {
        var result = await _orderFacade.GetOrdersByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("{orderId}")]
    public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
    {
        var result = await _orderFacade.GetOrderById(orderId);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
    {
        var result = await _orderFacade.AddOrderItem(command);
        return CommandResult(result);
    }
    [HttpPost("Checkout")]
    public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
    {
        var result = await _orderFacade.OrderCheckOut(command);
        return CommandResult(result);
    }
    [HttpPut("orderItem/IncreaseCount")]
    public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.IncreaseItemCount(command);
        return CommandResult(result);
    }
    [HttpPut("orderItem/DecreaseCount")]
    public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
    {
        var result = await _orderFacade.DecreaseItemCount(command);
        return CommandResult(result);
    }
    [HttpDelete("orderItem")]
    public async Task<ApiResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        var result = await _orderFacade.RemoveOrderItem(command);
        return CommandResult(result);
    }
}