namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SocialMedias", "Title");
            DropColumn("dbo.SocialMedias", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SocialMedias", "Description", c => c.String());
            AddColumn("dbo.SocialMedias", "Title", c => c.String());
        }
    }
}
