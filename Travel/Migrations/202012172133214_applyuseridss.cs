namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyuseridss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForTrips", "PricePersons", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForTrips", "PricePersons");
        }
    }
}
