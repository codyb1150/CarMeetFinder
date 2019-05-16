namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Isgoing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meet", "IsGoing", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meet", "IsGoing");
        }
    }
}
