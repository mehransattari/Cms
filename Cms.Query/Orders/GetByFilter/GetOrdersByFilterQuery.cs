using Cms.Query.Orders.DTOs;
using Common.Query;
using Cms.Query.Comments.DTOs;

namespace Cms.Query.Orders.GetByFilter;

public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}