namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMedias", "Status");
        }
    }
}
