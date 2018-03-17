namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OpportunityId = c.Guid(nullable: false),
                        ReplyId = c.Guid(),
                        CommentDate = c.DateTime(nullable: false),
                        ArchivedOn = c.DateTime(),
                        CommentString = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Opportunities", t => t.OpportunityId, cascadeDelete: true)
                .Index(t => t.OpportunityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Organization = c.String(),
                        Location = c.String(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Opportunities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        OpportunitySubject = c.String(),
                        Value = c.String(),
                        RemovedOn = c.DateTime(),
                        ResolvedOn = c.DateTime(),
                        ResolutionReason = c.String(),
                        IdentityUserId = c.String(maxLength: 128),
                        PriorityType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUserId)
                .ForeignKey("dbo.PriorityTypes", t => t.PriorityType_Id)
                .Index(t => t.ContactId)
                .Index(t => t.IdentityUserId)
                .Index(t => t.PriorityType_Id);
            
            CreateTable(
                "dbo.OpportunityDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationText = c.String(),
                        OpportunityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Opportunities", t => t.OpportunityId, cascadeDelete: true)
                .Index(t => t.OpportunityId);
            
            CreateTable(
                "dbo.DonationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationTypeString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriorityString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpportunitySteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpportunityId = c.Guid(nullable: false),
                        StepOrder = c.Int(nullable: false),
                        Step = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Opportunities", t => t.OpportunityId, cascadeDelete: true)
                .Index(t => t.OpportunityId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.DonationTypeOpportunityDonations",
                c => new
                    {
                        DonationType_Id = c.Int(nullable: false),
                        OpportunityDonation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DonationType_Id, t.OpportunityDonation_Id })
                .ForeignKey("dbo.DonationTypes", t => t.DonationType_Id, cascadeDelete: true)
                .ForeignKey("dbo.OpportunityDonations", t => t.OpportunityDonation_Id, cascadeDelete: true)
                .Index(t => t.DonationType_Id)
                .Index(t => t.OpportunityDonation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OpportunitySteps", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.Opportunities", "PriorityType_Id", "dbo.PriorityTypes");
            DropForeignKey("dbo.Opportunities", "IdentityUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OpportunityDonations", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.DonationTypeOpportunityDonations", "OpportunityDonation_Id", "dbo.OpportunityDonations");
            DropForeignKey("dbo.DonationTypeOpportunityDonations", "DonationType_Id", "dbo.DonationTypes");
            DropForeignKey("dbo.Opportunities", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Comments", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DonationTypeOpportunityDonations", new[] { "OpportunityDonation_Id" });
            DropIndex("dbo.DonationTypeOpportunityDonations", new[] { "DonationType_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OpportunitySteps", new[] { "OpportunityId" });
            DropIndex("dbo.OpportunityDonations", new[] { "OpportunityId" });
            DropIndex("dbo.Opportunities", new[] { "PriorityType_Id" });
            DropIndex("dbo.Opportunities", new[] { "IdentityUserId" });
            DropIndex("dbo.Opportunities", new[] { "ContactId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "OpportunityId" });
            DropTable("dbo.DonationTypeOpportunityDonations");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OpportunitySteps");
            DropTable("dbo.PriorityTypes");
            DropTable("dbo.DonationTypes");
            DropTable("dbo.OpportunityDonations");
            DropTable("dbo.Opportunities");
            DropTable("dbo.Contacts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
