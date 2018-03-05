using System;
using System.Collections.Generic;
using System.Linq;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Services.Services
{
    public class OpportunityService : IOpportunityHandler
    {
        private readonly ExecutiveContext _context;

        public OpportunityService(ExecutiveContext context)
        {
            _context = context;
        }

        public bool AddOpportunity(Guid contactId, string value, int priority)
        {
            if (!ContactExists(contactId)) return false;
            _context.Opportunities.Add(new Opportunity
            {
                ContactId = contactId,
                Value = value,
                OpportunityPriorityId = priority
            });
            _context.SaveChanges();
            return true;
        }

        public bool RemoveOpportunity(Guid opportunityId)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.RemovedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public bool UpdateOpportunity(Guid opportunityId, string newValue, int? newPriority = null)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.Value = newValue;
            if (newPriority != null)
                opportunity.OpportunityPriorityId = (int)newPriority;
            _context.SaveChanges();
            return true;
        }

        public bool ResolveOpportunity(Guid opportunityId, string resolutionReason)
        {
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.ResolvedOn = DateTime.Now;
            opportunity.ResolutionReason = resolutionReason;
            _context.SaveChanges();
            return true;
        }

        public bool SetPriorityLevel(Guid opportunityId, int priorityLevel)
        {
            if (!PriorityLevelExists(priorityLevel)) return false;
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            if (opportunity == null) return false;
            opportunity.OpportunityPriorityId = priorityLevel;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ViewModels.Opportunity> GetOpportunities()
        {
            var results = _context.Opportunities;
            var returned = new List<ViewModels.Opportunity>();
            foreach (var opportunity in results)
            {
                returned.Add(new ViewModels.Opportunity()
                {
                    
                });
            }



            return returned;
        }

        public IEnumerable<ViewModels.Opportunity> GetOpportunitiesForContact(Guid contactId)
        {
            throw new NotImplementedException();
        }


        private bool ContactExists(Guid contactId)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == contactId) != null;
        }

        private bool PriorityLevelExists(int priorityId)
        {
            return _context.OpportunityPriorities.FirstOrDefault(x => x.Id == priorityId) != null;
        }
    }
}