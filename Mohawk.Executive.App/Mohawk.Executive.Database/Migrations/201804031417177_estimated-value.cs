namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estimatedvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opportunities", "Description", c => c.String());
            AddColumn("dbo.Opportunities", "EstimatedValue", c => c.String());
            DropColumn("dbo.Opportunities", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Opportunities", "Value", c => c.String());
            DropColumn("dbo.Opportunities", "EstimatedValue");
            DropColumn("dbo.Opportunities", "Description");
        }
    }
}
