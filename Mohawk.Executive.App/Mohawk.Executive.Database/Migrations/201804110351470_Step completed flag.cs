namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stepcompletedflag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpportunitySteps", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpportunitySteps", "Completed");
        }
    }
}
