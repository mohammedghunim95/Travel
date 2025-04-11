namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedtables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "MeanOfTransportation", c => c.String());
            AlterColumn("dbo.Regions", "TouristProgram", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regions", "TouristProgram", c => c.String(nullable: false));
            DropColumn("dbo.Regions", "MeanOfTransportation");
        }
    }
}
