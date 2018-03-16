using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Database.Entities.UDT
{
    public class OpportunityStep
    {
        [Key]
        public int Id { get; set; }
        public Guid OpportunityId { get; set; }

        public int StepOrder { get; set; }
        public string Step { get; set; }

        public virtual Opportunity Opportunity { get; set; }    
    }
}
