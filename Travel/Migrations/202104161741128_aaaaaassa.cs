namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaassa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "UploadImage");
            DropColumn("dbo.AspNetUsers", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UploadImage", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
        }
    }
}
