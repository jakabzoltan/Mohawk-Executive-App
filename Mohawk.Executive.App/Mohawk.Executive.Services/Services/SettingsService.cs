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
        public IEnumerable<DonationTypeModel> GetDonationTypes()
        {
            return _context.DonationTypes.Select(x => new DonationTypeModel()
            {
                Id = x.Id,
                DonationTypeString = x.DonationTypeString
            });
        }

        public DonationTypeModel AddDonationType(string donationType)
        {
            throw new NotImplementedException();
        }

        public DonationTypeModel UpdateDonationType(int id, string donationType)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDonationType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriorityTypeModel> GetPriorities()
        {
            return _context.PriorityTypes.Select(x => new PriorityTypeModel()
            {
                Id = x.Id,
                PriorityString = x.PriorityString
            });
        }

        public PriorityTypeModel AddOpportunityPriority(string priorityText)
        {
            throw new NotImplementedException();
        }

        public PriorityTypeModel UpdateOpportunityPriority(int id, string priorityText)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOpportunity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
