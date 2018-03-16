using System;
using System.Collections.Generic;

namespace Mohawk.Executive.Services.ViewModels
{
    public class Comment
    {
        public Comment()
        {
            Replies = new List<Comment>();
        }
        public Guid Id { get; set; }
        public Guid OpportunityId { get; set; }
        public DateTime CommentDate { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public string CommentString { get; set; }
        public IdentityUserModel PostedBy { get; set; }

        public IEnumerable<Comment> Replies { get; set; }
    }
}