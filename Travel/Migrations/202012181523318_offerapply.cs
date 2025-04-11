namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offerapply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForTripOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        NumberPerson = c.String(),
                        OfferId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.offers", t => t.OfferId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.OfferId)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForTripOffers", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForTripOffers", "OfferId", "dbo.offers");
            DropIndex("dbo.ApplyForTripOffers", new[] { "user_Id" });
            DropIndex("dbo.ApplyForTripOffers", new[] { "OfferId" });
            DropTable("dbo.ApplyForTripOffers");
        }
    }
}
