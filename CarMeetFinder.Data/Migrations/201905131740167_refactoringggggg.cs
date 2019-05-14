namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoringggggg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Member", "CarID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "CarID", c => c.Int(nullable: false));
        }
    }
}
