using System;
using System.Collections.Generic;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IOpportunityHandler
    {
        bool AddOpportunity(Guid contactId, string subject, string value, int priority);
        bool RemoveOpportunity(Guid opportunityId);
        bool UpdateOpportunity(Guid opportunityId, string newSubject, string newValue, int? newPriority = null);
        bool ResolveOpportunity(Guid opportunityId, string resolutionReason);
        bool SetPriorityLevel(Guid opportunityId, int priorityLevel);

        IEnumerable<Opportunity> GetOpportunities(bool includePeripheral = false);
        IEnumerable<Opportunity> GetOpportunitiesForContact(Guid contactId, bool includePeripherals = false);
        Opportunity Get(Guid opportunityId, bool includePeripheral = false);
    }
}