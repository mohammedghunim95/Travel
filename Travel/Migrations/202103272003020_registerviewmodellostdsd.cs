namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerviewmodellostdsd : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RegisterViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UploadImage = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
