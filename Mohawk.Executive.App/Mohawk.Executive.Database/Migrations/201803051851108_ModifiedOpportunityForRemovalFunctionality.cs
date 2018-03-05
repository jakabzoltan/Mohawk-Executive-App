namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOpportunityForRemovalFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunities", "RemovedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Opportunities", "RemovedOn");
        }
    }
}
