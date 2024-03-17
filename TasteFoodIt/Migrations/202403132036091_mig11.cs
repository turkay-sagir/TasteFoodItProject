namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaId = c.Int(nullable: false, identity: true),
                        PlatformName = c.String(),
                        IconUrl = c.String(),
                        RedirectUrl = c.String(),
                    })
                .PrimaryKey(t => t.SocialMediaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialMedias");
        }
    }
}
