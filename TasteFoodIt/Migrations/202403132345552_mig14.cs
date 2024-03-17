namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IconUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IconUrl");
        }
    }
}
