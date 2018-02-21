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
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext() : base("MohawkExecutiveDb")
        {
            
        }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DonationType> DonationTypes { get; set; }
        public DbSet<OpportunityDonations> OpportunityDonations { get; set; }
        public DbSet<OpportunityPriority> OpportunityPriorities { get; set; }
        public DbSet<OpportunityStep> OpportunitySteps { get; set; }
    }
}
