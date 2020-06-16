namespace WebApp_FullProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjhb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Settings", newName: "PageSettings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PageSettings", newName: "Settings");
        }
    }
}
