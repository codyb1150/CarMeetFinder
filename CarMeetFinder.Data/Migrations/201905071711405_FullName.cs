namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "LastName", c => c.String());
            AlterColumn("dbo.Member", "FirstName", c => c.String());
        }
    }
}
