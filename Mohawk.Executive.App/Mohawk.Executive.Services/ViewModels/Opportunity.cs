using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Mohawk.Executive.Services.ViewModels
{
    public class Opportunity
    {
        public Opportunity()
        {
            Steps = new List<OpportunityStep>();
            Donations = new List<OpportunityDonation>();
            Comments = new List<Comment>();
        }
        public Guid Id { get; set; }
        [DisplayName("Priority Level")]
        public int OpportunityPriorityId { get; set; }
        public Guid ContactId { get; set; }
        [DisplayName("Subject")]
        [Required(ErrorMessage = "You must have a subject or goal for your opportunity.")]
        public string OpportunitySubject { get; set; }
        [Required(ErrorMessage = "You must explain the value of the opportunity.")]
        public string Value { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        [DisplayName("Outcome")]
        public string ResolutionReason { get; set; }

        public OpportunityPriority Priority { get; set; }
        public IEnumerable<OpportunityStep> Steps { get; set; }
        public IEnumerable<OpportunityDonation> Donations { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}