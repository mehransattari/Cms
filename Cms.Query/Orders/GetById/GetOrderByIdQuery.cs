using Cms.Query.Orders.DTOs;
using Common.Query;

namespace Cms.Query.Orders.GetById;

public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;