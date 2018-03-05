using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface ICommentHandler
    {
        bool AddComment(Guid opportunityId, string commentString, Guid? replyToId = null);
        bool RemoveComment(Guid commentId);
        bool EditComment(Guid commentId, string comment);
    }
}
