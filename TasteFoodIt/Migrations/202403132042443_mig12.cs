namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "Title", c => c.String());
            AddColumn("dbo.SocialMedias", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMedias", "Description");
            DropColumn("dbo.SocialMedias", "Title");
        }
    }
}
