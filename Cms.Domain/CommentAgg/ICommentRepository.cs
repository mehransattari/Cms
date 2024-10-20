using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain.CommentAgg
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
    }
}