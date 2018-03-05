using System;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IOpportunityHandler
    {
        bool AddOpportunity(Guid contactId, string value, int priority);
        bool RemoveOpportunity(Guid opportunityId);
        bool UpdateOpportunity(Guid opportunityId, string newValue, int? newPriority = null);
        bool ResolveOpportunity(Guid opportunityId);
        bool SetPriorityLevel(Guid opportunityId, int priorityLevel);

        void GetOpportunities();
        void GetOpportunitiesForContact(Guid contactId);
    }
}