using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Services.ViewModels
{
    public class Contact
    {
        public Contact()
        {
            Opportunities = new List<Opportunity>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Location { get; set; }
        public DateTime? ModifiedOn { get; set; }


        //navigation properties
        public IEnumerable<Opportunity> Opportunities { get; set; }
    }
}
