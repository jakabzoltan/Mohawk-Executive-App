using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Database.Entities.UDT;

namespace Mohawk.Executive.Database
{
    public class ExecutiveContext : IdentityDbContext
    {
        public ExecutiveContext() : base("MohawkExecutiveDb")
        {
            
        }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DonationType> DonationTypes { get; set; }
        public DbSet<PriorityType> PriorityTypes { get; set; }
        public DbSet<OpportunityDonation> OpportunityDonations { get; set; }
        public DbSet<OpportunityStep> OpportunitySteps { get; set; }

        public static ExecutiveContext Create()
        {
            return new ExecutiveContext();
        }
    }
}
