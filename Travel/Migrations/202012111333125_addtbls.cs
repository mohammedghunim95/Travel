namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TripType = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        TouristProgram = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Regions", new[] { "CountryId" });
            DropTable("dbo.Regions");
            DropTable("dbo.Countries");
        }
    }
}
