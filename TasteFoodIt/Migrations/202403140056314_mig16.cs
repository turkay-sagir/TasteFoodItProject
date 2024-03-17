namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ProfilePhoto", c => c.String());
            AddColumn("dbo.Admins", "NameSurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "NameSurname");
            DropColumn("dbo.Admins", "ProfilePhoto");
        }
    }
}
