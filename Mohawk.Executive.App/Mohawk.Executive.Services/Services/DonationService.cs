using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohawk.Executive.Database;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Database.Entities.UDT;
using Mohawk.Executive.Services.Interfaces;

namespace Mohawk.Executive.Services.Services
{
    public class DonationService : IDonationHandler
    {
        private readonly ExecutiveContext _context;

        public DonationService()
        {
            _context = ExecutiveContext.Create();
        }

        public bool AddDonation(Guid opportunityId, string donationText, params int[] donationTypes)
        {

            var donationsTypesList = _context.DonationTypes.Where(x => donationTypes.Any(y => y == x.Id)).ToList();
            var opportunity = _context.Opportunities.FirstOrDefault(x => x.Id == opportunityId);
            var donation = new OpportunityDonation()
            {
                OpportunityId = opportunityId,
                DonationText = donationText,
                DonationTypes = donationsTypesList
            };

            //_context.OpportunityDonations.Add(donation);
            if (opportunity != null && opportunity.Donations == null)
            {
                opportunity.Donations = new List<OpportunityDonation>();
                ((List<OpportunityDonation>) opportunity.Donations).Add(donation);
            }
            else
            {
                opportunity?.Donations?.Add(donation);
            }

            _context.SaveChanges();
            return true;
        }

        public bool RemoveDonation(int donationId)
        {
            var toRemove = _context.OpportunityDonations.FirstOrDefault(x => x.Id == donationId);
            if (toRemove == null) return false;
            _context.OpportunityDonations.Remove(toRemove);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateDonation(int donationId, string donationText, params int[] donationTypes)
        {
            var donationsTypesList = _context.DonationTypes.Where(x => donationTypes.Any(y => y == x.Id)).ToList();
            var toUpdate = _context.OpportunityDonations.FirstOrDefault(x => x.Id == donationId);
            if (toUpdate == null) return false;
            toUpdate.DonationText = donationText;
            toUpdate.DonationTypes = donationsTypesList;
            _context.SaveChanges();
            return true;
        }
    }
}
