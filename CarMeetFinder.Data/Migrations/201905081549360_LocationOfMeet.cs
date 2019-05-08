namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationOfMeet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meet", "LocationOfMeet", c => c.String());
            DropColumn("dbo.Meet", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meet", "Location", c => c.String());
            DropColumn("dbo.Meet", "LocationOfMeet");
        }
    }
}
