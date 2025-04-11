namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Companies_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Companies_Id");
            AddForeignKey("dbo.AspNetUsers", "Companies_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Companies_Id", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Companies_Id" });
            DropColumn("dbo.AspNetUsers", "Companies_Id");
            DropColumn("dbo.AspNetUsers", "CompanyId");
            DropTable("dbo.Companies");
        }
    }
}
