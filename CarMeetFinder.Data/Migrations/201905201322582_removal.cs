namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meet", "IsGoing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meet", "IsGoing", c => c.Boolean(nullable: false));
        }
    }
}
