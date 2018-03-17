using System;
using System.Collections.Generic;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Interfaces
{
    public interface IOpportunityHandler
    {
        OpportunityModel AddOpportunity(Guid contactId, string subject, string value, int priority, string userId);
        bool RemoveOpportunity(Guid opportunityId);
        OpportunityModel UpdateOpportunity(Guid opportunityId, string newSubject, string newValue, int? newPriority = null);
        OpportunityModel ResolveOpportunity(Guid opportunityId, string resolutionReason);
        OpportunityModel SetPriorityLevel(Guid opportunityId, int priorityLevel);

        IEnumerable<OpportunityModel> GetOpportunities(bool includePeripheral = false);
        IEnumerable<OpportunityModel> GetOpportunitiesForContact(Guid contactId, bool includePeripherals = false);
        IEnumerable<OpportunityModel> SearchOpportunities(string query, bool includePeripherals = false);
        OpportunityModel Get(Guid opportunityId, bool includePeripheral = false);
    }
}