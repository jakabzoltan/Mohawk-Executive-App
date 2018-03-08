using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please Enter a name.")]
        public string Name { get; set; }
        public string Role { get; set; }
        [DisplayName("Phone Number")]
        [Phone(ErrorMessage = "Invalid Phone Number Format.")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public string Organization { get; set; }
        public string Location { get; set; }
        public DateTime? ModifiedOn { get; set; }


        //navigation properties
        public IEnumerable<Opportunity> Opportunities { get; set; }
    }
}
