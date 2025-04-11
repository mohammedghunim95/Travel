namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dertys : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.offers", "ThingsToDo", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.offers", "ThingsToDo", c => c.String());
        }
    }
}
