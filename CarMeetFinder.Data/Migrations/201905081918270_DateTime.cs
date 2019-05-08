namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meet", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meet", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
