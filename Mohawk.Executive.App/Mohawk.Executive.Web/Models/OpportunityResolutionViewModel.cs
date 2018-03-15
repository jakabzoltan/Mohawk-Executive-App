using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Mohawk.Executive.Web.Models
{
    public class OpportunityResolutionViewModel
    {
        public OpportunityResolutionViewModel()
        {
            
        }
        public OpportunityResolutionViewModel(Guid id) : this()
        {
            OpportunityId = id;
        }
        public Guid OpportunityId { get; set; }
        [DisplayName("Resolution")]
        public string ResolutionReason { get; set; }
    }
}