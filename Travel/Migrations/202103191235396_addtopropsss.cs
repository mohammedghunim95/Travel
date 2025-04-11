namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtopropsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Video", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Video");
        }
    }
}
