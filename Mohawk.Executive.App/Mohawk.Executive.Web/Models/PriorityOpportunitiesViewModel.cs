using System.Collections.Generic;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Web.Models
{
    public class PriorityOpportunitiesViewModel
    {
        public PriorityOpportunitiesViewModel()
        {
            Opportunities = new List<OpportunityModel>();
        }
        public int Id { get; set; }
        public IEnumerable<OpportunityModel> Opportunities;

    }
}