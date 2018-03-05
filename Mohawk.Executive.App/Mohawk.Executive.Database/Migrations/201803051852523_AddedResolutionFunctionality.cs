namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResolutionFunctionality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunities", "ResolutionReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Opportunities", "ResolutionReason");
        }
    }
}
