namespace PonyRidesWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Session", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Time");
            DropColumn("dbo.Bookings", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Time", c => c.DateTime(nullable: false, precision: 0));
            DropColumn("dbo.Bookings", "Session");
        }
    }
}
