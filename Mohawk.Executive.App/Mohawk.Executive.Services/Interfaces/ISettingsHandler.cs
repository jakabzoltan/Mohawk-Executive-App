using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface ISettingsHandler
    {
        #region DonationTypes
        IEnumerable<DonationType> GetDonationTypes();
        DonationType AddDonationType(string donationType);
        DonationType UpdateDonationType(int id, string donationType);
        bool RemoveDonationType(int id);
        #endregion

        #region OpportunityPriority
        IEnumerable<OpportunityPriority> GetPriorities();
        OpportunityPriority AddOpportunityPriority(string priorityText);
        OpportunityPriority UpdateOpportunityPriority(int id, string priorityText);
        bool RemoveOpportunity(int id);
        #endregion



    }
}
