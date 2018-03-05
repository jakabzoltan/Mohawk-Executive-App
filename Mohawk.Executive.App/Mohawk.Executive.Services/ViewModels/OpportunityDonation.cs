using System;
using System.Collections.Generic;
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
        public string DonationText { get; set; }
        public IEnumerable<DonationType> DonationTypes { get; set; }
    }
}
