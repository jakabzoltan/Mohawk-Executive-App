using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;

namespace Mohawk.Executive.Services.Services
{
    public class SettingsService : ISettingsHandler
    {
        private readonly ExecutiveContext _context;

        public SettingsService()
        {
            _context = ExecutiveContext.Create();
        }
        public IEnumerable<DonationType> GetDonationTypes()
        {
            return _context.DonationTypes.Select(x => new DonationType()
            {
                Id = x.Id,
                DonationTypeString = x.DonationTypeString
            });
        }

        public DonationType AddDonationType(string donationType)
        {
            throw new NotImplementedException();
        }

        public DonationType UpdateDonationType(int id, string donationType)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDonationType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OpportunityPriority> GetPriorities()
        {
            return _context.OpportunityPriorities.Select(x => new OpportunityPriority()
            {
                Id = x.Id,
                PriorityString = x.PriorityString
            });
        }

        public OpportunityPriority AddOpportunityPriority(string priorityText)
        {
            throw new NotImplementedException();
        }

        public OpportunityPriority UpdateOpportunityPriority(int id, string priorityText)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOpportunity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
