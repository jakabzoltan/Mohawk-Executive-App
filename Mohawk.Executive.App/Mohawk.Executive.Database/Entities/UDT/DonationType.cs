using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Database.Entities.UDT
{
    public class DonationType
    {
        public int Id { get; set; }
        public string DonationTypeString { get; set; }

        public virtual ICollection<OpportunityDonation> OpportunityDonations { get; set; }
    }
}
