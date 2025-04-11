namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Regions", "UserID");
            AddForeignKey("dbo.Regions", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Regions", new[] { "UserID" });
            DropColumn("dbo.Regions", "UserID");
        }
    }
}
