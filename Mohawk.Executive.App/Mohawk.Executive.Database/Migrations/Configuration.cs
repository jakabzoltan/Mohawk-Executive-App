using System.Collections.Generic;
using Mohawk.Executive.Database.Entities;

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
            var guids = new List<Guid>()
            {
                Guid.Parse("127a82a5-7ac4-4ea2-9908-c51d91b2d47c"),
                Guid.Parse("3403f1f8-ee68-489e-9edb-a7a070ef7b3a"),
                Guid.Parse("5603f1f8-ee68-489e-9edb-a7a070ef7b3a")
            };

            var guid0 = guids[0];
            var guid1 = guids[1];
            var guid2 = guids[2];

            if (context.Contacts.FirstOrDefault(x => x.Id == guid0) == null)
                context.Contacts.Add(new Contact()
                {
                    Id = guids[0],
                    Name = "Zoltan Jakab",
                    Email = "zoltan.jakab1@Mohawkcollege.ca",
                    Organization = "Mohawk College"
                });

            if (context.Contacts.FirstOrDefault(x => x.Id == guid1) == null)
                context.Contacts.Add(new Contact()
                {
                    Id = guids[1],
                    Name = "Erin Bradley",
                    Email = "erin.bradley@Mohawkcollege.ca",
                    Organization = "Mohawk College"
                });
            if (context.Contacts.FirstOrDefault(x => x.Id == guid2) == null)
                context.Contacts.Add(new Contact()
                {
                    Id = guids[2],
                    Name = "Filip Zizovski",
                    Email = "filip.zizovski@Mohawkcollege.ca",
                    Organization = "Mohawk College"
                });

            context.SaveChanges();


        }
    }
}
