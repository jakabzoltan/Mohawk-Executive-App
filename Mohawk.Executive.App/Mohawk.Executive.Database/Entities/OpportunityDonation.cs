using System;
using System.Collections.Generic;
using Mohawk.Executive.Database.Entities.UDT;

namespace Mohawk.Executive.Database.Entities
{
    public class OpportunityDonation
    {
        public int Id { get; set; }
        public string DonationText { get; set; }
        public Guid OpportunityId { get; set; }
        public virtual ICollection<DonationType> DonationTypes { get; set; }
        public virtual Opportunity Opportunity { get; set; }
    }
}
