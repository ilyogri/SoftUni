namespace _08.Create_User.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DAa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ProfilePicture", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ProfilePicture", c => c.Int(nullable: false));
        }
    }
}
