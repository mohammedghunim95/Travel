namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "CompanyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "CompanyName");
        }
    }
}
