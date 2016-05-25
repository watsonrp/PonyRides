namespace PonyRidesWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredBooking2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Day", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "Day");
        }
    }
}
