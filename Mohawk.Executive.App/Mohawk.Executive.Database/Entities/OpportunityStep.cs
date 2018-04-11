using System;
using System.ComponentModel.DataAnnotations;

namespace Mohawk.Executive.Database.Entities
{
    public class OpportunityStep
    {
        [Key]
        public int Id { get; set; }
        public Guid OpportunityId { get; set; }

        public int StepOrder { get; set; }
        public string Step { get; set; }
        public bool Completed { get; set; }
        public virtual Opportunity Opportunity { get; set; }    
    }
}
