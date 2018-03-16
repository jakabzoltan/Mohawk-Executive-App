using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohawk.Executive.Services.ViewModels
{
    public class OpportunityStep
    {
        public Guid OpportunityId { get; set; }
        public int StepOrder { get; set; }
        public string Step { get; set; }
    }
}