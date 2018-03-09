using Mohawk.Executive.Database.Entities.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Database.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Location { get; set; }
        public DateTime? ModifiedOn { get; set; }


        //navigation properties
        public virtual IEnumerable<Opportunity> Opportunities {get;set;}
    }
}
