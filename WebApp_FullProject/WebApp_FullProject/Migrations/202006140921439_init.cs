namespace WebApp_FullProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Surname = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        Title = c.String(nullable: false, maxLength: 250),
                        Subtitle = c.String(maxLength: 250),
                        Content = c.String(maxLength: 1000),
                        Page = c.String(nullable: false, maxLength: 50),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(nullable: false, maxLength: 150),
                        Title = c.String(maxLength: 250),
                        Subtitle = c.String(maxLength: 250),
                        Copyright = c.String(maxLength: 50),
                        BgImage = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 250),
                        Subtitle = c.String(maxLength: 250),
                        Sunday = c.String(maxLength: 25),
                        Munday = c.String(maxLength: 25),
                        Tuesday = c.String(maxLength: 25),
                        Wednesday = c.String(maxLength: 25),
                        Thursday = c.String(maxLength: 25),
                        Friday = c.String(maxLength: 25),
                        Saturday = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
            DropTable("dbo.Settings");
            DropTable("dbo.Sections");
            DropTable("dbo.Admins");
        }
    }
}
