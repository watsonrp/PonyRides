namespace PonyRidesWebSite.Migrations
{
    using Models.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<PonyRidesWebSite.Models.Data.PonyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PonyRidesWebSite.Models.Data.PonyContext context)
        {
            context.Ponies.AddOrUpdate(
                x => x.ID,
                new Pony { ID = 1, Name = "Flossy", Picture = "/media/ponies/flossy.png" },
                new Pony { ID = 2, Name = "Suri", Picture = "/media/ponies/suri.png" },
                new Pony { ID = 3, Name = "Trixie", Picture = "/media/ponies/trixie.png" },
                new Pony { ID = 4, Name = "Doris", Picture = "/media/ponies/doris.jpg" },
                new Pony { ID = 5, Name = "Applejack", Picture = "/media/ponies/applejack.jpg" },
                new Pony { ID = 6, Name = "Helen", Picture = "/media/ponies/helen.jpg" }
            );
        }
    }
}
