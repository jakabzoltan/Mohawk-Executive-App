using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Mohawk.Executive.Services.ViewModels
{
    public class OpportunityModel
    {
        public OpportunityModel()
        {
            Steps = new List<OpportunityStepModel>();
            Donations = new List<OpportunityDonationModel>();
            Comments = new List<CommentModel>();
        }
        public Guid Id { get; set; }
        [DisplayName("Priority Level")]
        public int PriorityId { get; set; }
        public Guid ContactId { get; set; }
        [DisplayName("OpportunitySubject")]
        [Required(ErrorMessage = "You must have a subject or goal for your opportunity.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "You must explain the value of the opportunity.")]
        public string Value { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        [DisplayName("Outcome")]
        public string ResolutionReason { get; set; }
        public string ActiveTab { get; set; }

        public PriorityTypeModel Priority { get; set; }
        public List<OpportunityStepModel> Steps { get; set; }
        [DisplayName("Importance")]
        public List<OpportunityDonationModel> Donations { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}