namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UploadImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UploadImage");
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
    }
}
