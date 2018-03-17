namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opportunityUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunities", "PosterId", c => c.String());
            AddColumn("dbo.Opportunities", "UserPoster_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.OpportunitySteps", "Opportunity_Id", c => c.Guid());
            CreateIndex("dbo.Opportunities", "UserPoster_Id");
            CreateIndex("dbo.OpportunitySteps", "Opportunity_Id");
            AddForeignKey("dbo.Opportunities", "UserPoster_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OpportunitySteps", "Opportunity_Id", "dbo.Opportunities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpportunitySteps", "Opportunity_Id", "dbo.Opportunities");
            DropForeignKey("dbo.Opportunities", "UserPoster_Id", "dbo.AspNetUsers");
            DropIndex("dbo.OpportunitySteps", new[] { "Opportunity_Id" });
            DropIndex("dbo.Opportunities", new[] { "UserPoster_Id" });
            DropColumn("dbo.OpportunitySteps", "Opportunity_Id");
            DropColumn("dbo.Opportunities", "UserPoster_Id");
            DropColumn("dbo.Opportunities", "PosterId");
        }
    }
}
