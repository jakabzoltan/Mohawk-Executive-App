using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohawk.Executive.Services.ViewModels
{
    public class ContactModel
    {
        public ContactModel()
        {
            Opportunities = new List<OpportunityModel>();
        }
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
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
        public IEnumerable<OpportunityModel> Opportunities { get; set; }
    }
}
