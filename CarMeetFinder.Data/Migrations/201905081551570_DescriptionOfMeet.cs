namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionOfMeet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meet", "DescriptionOfMeet", c => c.String());
            DropColumn("dbo.Meet", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meet", "Description", c => c.String());
            DropColumn("dbo.Meet", "DescriptionOfMeet");
        }
    }
}
