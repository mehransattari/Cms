using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Application.Comments.Create
{
    public record CreateCommentCommand(string Text, long UserId, long ProductId) : IBaseCommand;
}