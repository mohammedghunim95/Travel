namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtoprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "ThingsToDo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "ThingsToDo");
        }
    }
}
