namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "CarID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "CarID");
        }
    }
}
