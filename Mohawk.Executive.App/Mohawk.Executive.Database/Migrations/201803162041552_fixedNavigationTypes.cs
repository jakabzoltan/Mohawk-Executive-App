namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedNavigationTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpportunitySteps", "Opportunity_Id", "dbo.Opportunities");
            DropIndex("dbo.OpportunitySteps", new[] { "Opportunity_Id" });
            RenameColumn(table: "dbo.OpportunitySteps", name: "Opportunity_Id", newName: "OpportunityId");
            DropPrimaryKey("dbo.OpportunitySteps");
            AddColumn("dbo.DonationTypes", "OpportunityDonation_Id", c => c.Int());
            AlterColumn("dbo.OpportunitySteps", "OpportunityId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.OpportunitySteps", new[] { "OpportunityId", "StepOrder" });
            CreateIndex("dbo.Comments", "OpportunityId");
            CreateIndex("dbo.DonationTypes", "OpportunityDonation_Id");
            CreateIndex("dbo.OpportunitySteps", "OpportunityId");
            AddForeignKey("dbo.Comments", "OpportunityId", "dbo.Opportunities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DonationTypes", "OpportunityDonation_Id", "dbo.OpportunityDonations", "Id");
            AddForeignKey("dbo.OpportunitySteps", "OpportunityId", "dbo.Opportunities", "Id", cascadeDelete: true);
            DropColumn("dbo.OpportunitySteps", "OpportuntityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpportunitySteps", "OpportuntityId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.OpportunitySteps", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.DonationTypes", "OpportunityDonation_Id", "dbo.OpportunityDonations");
            DropForeignKey("dbo.Comments", "OpportunityId", "dbo.Opportunities");
            DropIndex("dbo.OpportunitySteps", new[] { "OpportunityId" });
            DropIndex("dbo.DonationTypes", new[] { "OpportunityDonation_Id" });
            DropIndex("dbo.Comments", new[] { "OpportunityId" });
            DropPrimaryKey("dbo.OpportunitySteps");
            AlterColumn("dbo.OpportunitySteps", "OpportunityId", c => c.Guid());
            DropColumn("dbo.DonationTypes", "OpportunityDonation_Id");
            AddPrimaryKey("dbo.OpportunitySteps", new[] { "OpportuntityId", "StepOrder" });
            RenameColumn(table: "dbo.OpportunitySteps", name: "OpportunityId", newName: "Opportunity_Id");
            CreateIndex("dbo.OpportunitySteps", "Opportunity_Id");
            AddForeignKey("dbo.OpportunitySteps", "Opportunity_Id", "dbo.Opportunities", "Id");
        }
    }
}
