namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Member", "FullName");
        }
    }
}
