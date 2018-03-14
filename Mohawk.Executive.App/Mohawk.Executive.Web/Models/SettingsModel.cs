using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class SettingsModel
    {
        public IEnumerable<DonationType> DonationTypes { get; set; }
        public IEnumerable<OpportunityPriority> OpportunityPriorities { get; set; }

        public SettingsModel()
        {
            DonationTypes = new List<DonationType>();
            OpportunityPriorities = new List<OpportunityPriority>();
        }

        public SettingsModel(IEnumerable<DonationType> donationTypes, IEnumerable<OpportunityPriority> opportunityPriorities) : this()
        {
            DonationTypes = donationTypes;
            OpportunityPriorities = opportunityPriorities;
        }
    }
}