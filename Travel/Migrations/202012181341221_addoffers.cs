namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addoffers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        TouristProgram = c.String(),
                        MeanOfTransportation = c.String(),
                        UserID = c.String(maxLength: 128),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.offers", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.offers", "CountryId", "dbo.Countries");
            DropIndex("dbo.offers", new[] { "CountryId" });
            DropIndex("dbo.offers", new[] { "UserID" });
            DropTable("dbo.offers");
        }
    }
}
