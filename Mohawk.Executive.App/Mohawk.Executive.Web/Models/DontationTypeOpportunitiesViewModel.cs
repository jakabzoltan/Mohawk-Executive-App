using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class DontationTypeOpportunitiesViewModel
    {
        public int Id { get; set; }
        public IEnumerable<OpportunityModel> Opportunities;
    }
}