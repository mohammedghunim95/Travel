namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForTrips", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForTrips", "UserId");
        }
    }
}
