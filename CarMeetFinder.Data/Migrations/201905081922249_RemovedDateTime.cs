namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meet", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meet", "DateCreated");
        }
    }
}
