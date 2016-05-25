namespace PonyRidesWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredBooking3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "CustomerID", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
