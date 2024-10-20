using Cms.Infrastructure._Utilities;
using Cms.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Cms.Domain.OrderAgg;
using Cms.Domain.OrderAgg.Repository;

namespace Cms.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(CmsContext context) : base(context)
        {
        }
        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }


    }
}