namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.offers", "ThingsToDo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.offers", "ThingsToDo");
        }
    }
}
