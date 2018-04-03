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
        public int PriorityId { get; set; }
        public Guid ContactId { get; set; }
        public string OpportunitySubject { get; set; }
        public string Description { get; set; }
        public string EstimatedValue { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string ResolutionReason { get; set; }
        public string IdentityUserId { get; set; }

        //navigation properties
        public virtual Contact Contact { get; set; }
        public virtual PriorityType PriorityType { get; set; }
        public virtual ICollection<OpportunityStep> Steps { get; set; }
        public virtual ICollection<OpportunityDonation> Donations { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
