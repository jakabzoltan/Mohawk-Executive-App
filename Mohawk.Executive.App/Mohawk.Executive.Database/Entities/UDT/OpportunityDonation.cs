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
        public virtual IEnumerable<DonationType> DonationTypes { get; set; }
        public virtual IEnumerable<Opportunity> Opportunities { get; set; }
    }
}
