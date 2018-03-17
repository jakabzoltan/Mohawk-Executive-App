using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class CommentViewModel : CommentModel
    {
        public CommentViewModel()
        {
            
        }

        public CommentViewModel(Guid opportunityId, Guid? replyToCommentId = null)
        {
            OpportunityId = opportunityId;
            ReplyToId = replyToCommentId;
        }

        public Guid? ReplyToId { get; set; }
    }
}