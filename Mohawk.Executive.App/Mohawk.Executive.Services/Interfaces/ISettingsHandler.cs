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
        bool RemoveDonationType(int id);
        DonationTypeModel EditDonationType(int id, string donationType);
        IEnumerable<Guid> GetAssociatedOpportunities(int id);

            #endregion

        #region OpportunityPriority
        IEnumerable<PriorityTypeModel> GetPriorities();
        PriorityTypeModel AddPriorityType(string priorityText);
        bool RemovePriorityType(int id);
        PriorityTypeModel EditPriorityType(int id, string priorityText);

        #endregion



    }
}
