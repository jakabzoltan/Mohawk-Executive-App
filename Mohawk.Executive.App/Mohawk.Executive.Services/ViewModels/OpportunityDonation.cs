using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Services.ViewModels
{
    public class OpportunityDonation
    {
        public OpportunityDonation()
        {
            DonationTypes = new List<DonationType>();
        }
        public int Id { get; set; }
        [DisplayName("Donation")]
        public string DonationText { get; set; }
        public Guid OpportunityId { get; set; }
        [DisplayName("Donation Types")]
        public List<DonationType> DonationTypes { get; set; }

    }
}
