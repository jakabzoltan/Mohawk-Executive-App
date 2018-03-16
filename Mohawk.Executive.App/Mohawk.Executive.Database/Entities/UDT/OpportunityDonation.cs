using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Database.Entities.UDT
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
