using System.Collections.Generic;
using Mohawk.Executive.Database.Entities;
using Mohawk.Executive.Database.Entities.UDT;

namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mohawk.Executive.Database.ExecutiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Mohawk.Executive.Database.ExecutiveContext context)
        {
            context.PriorityTypes.AddOrUpdate(
                new PriorityType()
                {
                    PriorityString = "Very Low Importance"
                },
                new PriorityType()
                {
                    PriorityString = "Low Importance"
                },
                new PriorityType()
                {
                    PriorityString = "Average Importance"
                },
                new PriorityType()
                {
                    PriorityString = "High Importance"
                },
                new PriorityType()
                {
                    PriorityString = "Critically Important"
                });

            context.DonationTypes.AddOrUpdate(
                new DonationType() { DonationTypeString = "In Kind Donation" },
                new DonationType() { DonationTypeString = "Monetary Donation" });
        }
    }
}