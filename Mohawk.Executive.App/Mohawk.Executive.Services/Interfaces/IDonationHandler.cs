using System;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IDonationHandler
    {
        bool AddDonation(Guid opportunityId, string donationText, params int[] donationTypes);
        bool RemoveDonation(int donationId);
        bool UpdateDonation(int donationId, string donationText, params int[] donationTypes);

    }

}