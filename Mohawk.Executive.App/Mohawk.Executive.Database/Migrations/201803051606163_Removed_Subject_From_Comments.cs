namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_Subject_From_Comments : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Subject", c => c.String());
        }
    }
}
