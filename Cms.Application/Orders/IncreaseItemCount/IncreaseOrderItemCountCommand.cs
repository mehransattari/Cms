using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Application.Orders.IncreaseItemCount
{
    public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}