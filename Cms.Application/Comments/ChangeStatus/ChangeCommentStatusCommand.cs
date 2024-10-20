using Common.Application;
using Cms.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(long Id, CommentStatus Status) : IBaseCommand;
}