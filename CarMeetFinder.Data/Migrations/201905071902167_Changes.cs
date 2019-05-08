namespace CarMeetFinder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "VehicleModel", c => c.String());
            DropColumn("dbo.Car", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Car", "Model", c => c.String());
            DropColumn("dbo.Car", "VehicleModel");
        }
    }
}
