using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Services.Interfaces;
using Mohawk.Executive.Services.ViewModels;
using Mohawk.Executive.Database.Entities.UDT;

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
            // throw new NotImplementedException();
            var dType = new DonationType()
            {
                DonationTypeString = donationType,
            };
            _context.DonationTypes.Add(dType);
            _context.SaveChanges();
            return GetDonationType(dType.Id);

        }


        public bool RemoveDonationType(int id)
        {
            //throw new NotImplementedException();

            var donation =_context.DonationTypes.FirstOrDefault(c => c.Id == id);

            if (donation == null) return false;
            _context.DonationTypes.Remove(donation);
            _context.SaveChanges();

            return true;
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

            // throw new NotImplementedException();
            var pType = new PriorityType()
            {
                PriorityString = priorityText,
            };
            _context.PriorityTypes.Add(pType);
            _context.SaveChanges();
            return GetPriorityType(pType.Id);
        }


        public bool RemoveOpportunityPriority(int id)
        {
            // throw new NotImplementedException();
            var priority = _context.PriorityTypes.FirstOrDefault(c => c.Id == id);

            if (priority == null) return false;
            _context.PriorityTypes.Remove(priority);
            _context.SaveChanges();

            return true;
        }

        public DonationTypeModel GetDonationType(int id)
        {
            return _context.DonationTypes.Where(c => c.Id == id).Select(c => new DonationTypeModel()
            {
                Id = c.Id,
                DonationTypeString = c.DonationTypeString,


            })
       
            .FirstOrDefault();
        }

        public PriorityTypeModel GetPriorityType(int id)
        {
            return _context.PriorityTypes.Where(c => c.Id == id).Select(c => new PriorityTypeModel()
            {
                Id = c.Id,
                PriorityString = c.PriorityString,

            })

            .FirstOrDefault();
        }
    }
}
