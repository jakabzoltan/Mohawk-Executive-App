using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Database.Entities.UDT
{
    public class PriorityType
    {
        public int Id { get; set; }
        public string PriorityString { get; set; }

        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
