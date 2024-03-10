namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Location", c => c.String());
            AddColumn("dbo.Addresses", "Website", c => c.String());
            AddColumn("dbo.Contacts", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsRead");
            DropColumn("dbo.Addresses", "Website");
            DropColumn("dbo.Addresses", "Location");
        }
    }
}
