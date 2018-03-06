﻿using System;
using System.Collections.Generic;


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
        public int OpportunityPriorityId { get; set; }
        public Guid ContactId { get; set; }

        public string OpportunitySubject { get; set; }
        public string Value { get; set; }
        public DateTime? RemovedOn { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string ResolutionReason { get; set; }

        public OpportunityPriority Priority { get; set; }
        public IEnumerable<OpportunityStep> Steps { get; set; }
        public IEnumerable<OpportunityDonation> Donations { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}