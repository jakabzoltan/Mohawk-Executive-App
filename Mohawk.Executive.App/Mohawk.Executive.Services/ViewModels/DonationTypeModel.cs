using System.ComponentModel;

namespace Mohawk.Executive.Services.ViewModels
{
    public class DonationTypeModel
    {
        public int Id { get; set; }
        [DisplayName("Donation Type")]
        public string DonationTypeString { get; set; }
    }
}