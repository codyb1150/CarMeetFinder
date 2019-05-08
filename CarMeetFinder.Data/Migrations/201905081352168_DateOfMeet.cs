namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfMeet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meet", "DateOfMeet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meet", "DateOfMeet");
        }
    }
}
