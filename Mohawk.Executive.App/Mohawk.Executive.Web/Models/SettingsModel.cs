using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class SettingsModel
    {
        public IEnumerable<DonationTypeModel> DonationTypes { get; set; }
        public IEnumerable<PriorityTypeModel> OpportunityPriorities { get; set; }

        public SettingsModel()
        {
            DonationTypes = new List<DonationTypeModel>();
            OpportunityPriorities = new List<PriorityTypeModel>();
        }

        public SettingsModel(IEnumerable<DonationTypeModel> donationTypes, IEnumerable<PriorityTypeModel> opportunityPriorities) : this()
        {
            DonationTypes = donationTypes;
            OpportunityPriorities = opportunityPriorities;
        }
    }
}