namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForTrips",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        PersonNumber = c.String(nullable: false),
                        RegionId = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.RegionId)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForTrips", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForTrips", "RegionId", "dbo.Regions");
            DropIndex("dbo.ApplyForTrips", new[] { "user_Id" });
            DropIndex("dbo.ApplyForTrips", new[] { "RegionId" });
            DropTable("dbo.ApplyForTrips");
        }
    }
}
