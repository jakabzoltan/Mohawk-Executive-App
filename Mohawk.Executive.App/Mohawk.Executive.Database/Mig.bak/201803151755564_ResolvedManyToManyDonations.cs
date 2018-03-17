namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResolvedManyToManyDonations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpportunityDonations", "OpportunityId", c => c.Guid(nullable: false));
            CreateIndex("dbo.OpportunityDonations", "OpportunityId");
            AddForeignKey("dbo.OpportunityDonations", "OpportunityId", "dbo.Opportunities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpportunityDonations", "OpportunityId", "dbo.Opportunities");
            DropIndex("dbo.OpportunityDonations", new[] { "OpportunityId" });
            DropColumn("dbo.OpportunityDonations", "OpportunityId");
        }
    }
}
