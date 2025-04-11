namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offerapplydds : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ApplyForTripOffers", new[] { "user_Id" });
            DropColumn("dbo.ApplyForTripOffers", "UserId");
            RenameColumn(table: "dbo.ApplyForTripOffers", name: "user_Id", newName: "UserId");
            AlterColumn("dbo.ApplyForTripOffers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplyForTripOffers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApplyForTripOffers", new[] { "UserId" });
            AlterColumn("dbo.ApplyForTripOffers", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ApplyForTripOffers", name: "UserId", newName: "user_Id");
            AddColumn("dbo.ApplyForTripOffers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForTripOffers", "user_Id");
        }
    }
}
