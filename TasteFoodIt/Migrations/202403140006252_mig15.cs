namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IconUrl", c => c.String());
            DropColumn("dbo.Products", "IconUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IconUrl", c => c.String());
            DropColumn("dbo.Categories", "IconUrl");
        }
    }
}
