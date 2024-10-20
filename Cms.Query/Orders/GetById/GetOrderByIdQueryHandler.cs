using Cms.Query.Orders;
using Cms.Query.Orders.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Cms.Infrastructure.Persistent.Dapper;
using Cms.Infrastructure.Persistent.Ef;

namespace Cms.Query.Orders.GetById;

internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly CmsContext _CmsContext;
    private readonly DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(CmsContext CmsContext, DapperContext dapperContext)
    {
        _CmsContext = CmsContext;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _CmsContext.Orders
            .FirstOrDefaultAsync(f => f.Id == request.OrderId, cancellationToken);
        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _CmsContext.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}