namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedOpportunity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunities", "OpportunitySubject", c => c.String());
            DropColumn("dbo.Opportunities", "Outcome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Opportunities", "Outcome", c => c.String());
            DropColumn("dbo.Opportunities", "OpportunitySubject");
        }
    }
}
