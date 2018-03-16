﻿using System;
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
        [Key, Column(Order = 0)]
        public Guid OpportuntityId { get; set; }
        [Key, Column(Order = 1)]
        public int StepOrder { get; set; }
        public string Step { get; set; }

        public virtual Opportunity Opportunity { get; set; }    
    }
}
