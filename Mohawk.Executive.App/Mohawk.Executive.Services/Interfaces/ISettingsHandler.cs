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
        IEnumerable<DonationTypeModel> GetDonationTypes();
        DonationTypeModel AddDonationType(string donationType);
        DonationTypeModel UpdateDonationType(int id, string donationType);
        bool RemoveDonationType(int id);
        #endregion

        #region OpportunityPriority
        IEnumerable<PriorityTypeModel> GetPriorities();
        PriorityTypeModel AddOpportunityPriority(string priorityText);
        PriorityTypeModel UpdateOpportunityPriority(int id, string priorityText);
        bool RemoveOpportunity(int id);
        #endregion



    }
}
