using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class OpportunityCreateViewModel : Opportunity
    {
        public OpportunityCreateViewModel()
        {
            PrioritiesList = new List<SelectListItem>();
        }

        public int[] Selected { get; set; }
        
        public IEnumerable<SelectListItem> PrioritiesList { get; set; }
    }
}