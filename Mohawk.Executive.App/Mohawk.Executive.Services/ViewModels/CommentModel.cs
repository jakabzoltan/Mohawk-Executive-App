using System;
using System.Collections.Generic;

namespace Mohawk.Executive.Services.ViewModels
{
    public class CommentModel
    {
        public CommentModel()
        {
            Replies = new List<CommentModel>();
        }
        public Guid Id { get; set; }
        public Guid OpportunityId { get; set; }
        public DateTime CommentDate { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public string CommentString { get; set; }
        public IdentityUserModel PostedBy { get; set; }

        public List<CommentModel> Replies { get; set; }
    }
}