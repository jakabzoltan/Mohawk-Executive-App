using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mohawk.Executive.Database.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid OpportunityId { get; set; }
        //not null if the comment is a reply, null otherwise.
        public Guid? ReplyId { get; set; }
        public DateTime CommentDate { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public string CommentString { get; set; }
        public string UserId { get; set; }


        public virtual IdentityUser User { get; set; }
    }
}
