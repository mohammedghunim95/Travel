namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaassasadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "CoronaStatus", c => c.String(nullable: false));
            AddColumn("dbo.Regions", "CoronaDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "CoronaDescription");
            DropColumn("dbo.Regions", "CoronaStatus");
        }
    }
}
