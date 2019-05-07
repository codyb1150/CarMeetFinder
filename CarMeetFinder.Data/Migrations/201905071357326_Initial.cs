namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "Make", c => c.String());
            AddColumn("dbo.Car", "Model", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "Model");
            DropColumn("dbo.Car", "Make");
        }
    }
}
