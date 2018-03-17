using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Services.ViewModels
{
    public class OpportunityDonationModel
    {
        public OpportunityDonationModel()
        {
            DonationTypes = new List<DonationTypeModel>();
        }
        public int Id { get; set; }
        [DisplayName("Donation")]
        public string DonationText { get; set; }
        public Guid OpportunityId { get; set; }
        [DisplayName("Donation Types")]
        public List<DonationTypeModel> DonationTypes { get; set; }

    }
}
