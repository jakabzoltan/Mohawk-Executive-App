namespace Mohawk.Executive.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstNameLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "FirstName", c => c.String());
            AddColumn("dbo.Contacts", "LastName", c => c.String());
            DropColumn("dbo.Contacts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Name", c => c.String());
            DropColumn("dbo.Contacts", "LastName");
            DropColumn("dbo.Contacts", "FirstName");
        }
    }
}
