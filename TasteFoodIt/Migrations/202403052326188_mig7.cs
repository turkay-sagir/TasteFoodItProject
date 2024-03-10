namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpenDayHours", "Selected", c => c.Boolean(nullable: false));
            DropColumn("dbo.OpenDayHours", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpenDayHours", "IsSelected", c => c.Boolean(nullable: false));
            DropColumn("dbo.OpenDayHours", "Selected");
        }
    }
}
