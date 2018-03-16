using Mohawk.Executive.Database.Entities.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mohawk.Executive.Database.Entities
{
    public class Opportunity
    {
        public Guid Id { get; set; }
        public int OpportunityPriorityId { get; set; }
        public Guid ContactId { get; set; }
        public string OpportunitySubject { get; set; }
        public string Value { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string ResolutionReason { get; set; }
        public string PosterId { get; set; }

        //navigation properties
        public virtual Contact Contact { get; set; }
        public virtual OpportunityPriority Priority { get; set; }
        public virtual IEnumerable<OpportunityStep> Steps { get; set; }
        public virtual IEnumerable<OpportunityDonation> Donations { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IdentityUser UserPoster { get; set; }
    }
}
