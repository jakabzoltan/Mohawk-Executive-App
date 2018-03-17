using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Services.Services
{
    public class CommentService : ICommentHandler
    {
        private readonly ExecutiveContext _context;

        public CommentService()
        {
            _context = ExecutiveContext.Create();
        }

        public bool AddComment(Guid opportunityId, string commentString, string userId, Guid? replyToId = null)
        {
            if (replyToId != null)
                if (!IsCommentHead(replyToId))
                    return false;
            _context.Comments.Add(new Comment()
            {
                Id = Guid.NewGuid(),
                CommentDate = DateTime.Now,
                UserId = userId,
                CommentString = commentString,
                OpportunityId = opportunityId,
                ReplyId = replyToId,
            });
            _context.SaveChanges();
            return true;
        }

        public bool RemoveComment(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public bool EditComment(Guid commentId, string comment)
        {
            throw new NotImplementedException();
        }

        private bool IsCommentHead(Guid? repliedToId)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == repliedToId)?.ReplyId == null;
        }
    }
}
