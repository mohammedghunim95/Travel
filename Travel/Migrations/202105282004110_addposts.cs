namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UserName");
        }
    }
}
