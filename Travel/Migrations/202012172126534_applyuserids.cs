namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyuserids : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ApplyForTrips", new[] { "user_Id" });
            DropColumn("dbo.ApplyForTrips", "UserId");
            RenameColumn(table: "dbo.ApplyForTrips", name: "user_Id", newName: "UserId");
            AlterColumn("dbo.ApplyForTrips", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplyForTrips", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApplyForTrips", new[] { "UserId" });
            AlterColumn("dbo.ApplyForTrips", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ApplyForTrips", name: "UserId", newName: "user_Id");
            AddColumn("dbo.ApplyForTrips", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForTrips", "user_Id");
        }
    }
}
