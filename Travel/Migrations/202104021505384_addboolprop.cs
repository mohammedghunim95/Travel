namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboolprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForTrips", "HiringTourGuide", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForTrips", "HiringTourGuide");
        }
    }
}
