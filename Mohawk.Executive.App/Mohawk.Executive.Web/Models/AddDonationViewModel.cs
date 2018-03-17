﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class AddDonationViewModel : OpportunityDonationModel
    {
        public AddDonationViewModel()
        {
            DonationList = new List<SelectListItem>();
        }

        public AddDonationViewModel(Guid opportunityId) : this()
        {
            OpportunityId = opportunityId;
        }
        public int[] Selected { get; set; }
        
        public IEnumerable<SelectListItem> DonationList { get; set; }
    }
}