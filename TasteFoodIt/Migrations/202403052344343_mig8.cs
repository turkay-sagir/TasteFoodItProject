namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OpenDayHours", "Selected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpenDayHours", "Selected", c => c.Boolean(nullable: false));
        }
    }
}
