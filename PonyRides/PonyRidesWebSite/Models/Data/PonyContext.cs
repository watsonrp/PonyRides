using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using static PonyRidesWebSite.Migrations.Configuration;

namespace PonyRidesWebSite.Models.Data
{
    class PonyContext : DbContext  
    {
        public DbSet<Pony> Ponies { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public PonyContext() : base("PonyDBConnection")
        {
            Database.SetInitializer(new PonyContextInitializer());
            // Database.SetInitializer(new CreateAndMigrateDatabaseInitializer<PonyContext, PonyRidesWebSite.Migrations.Configuration>());
            // Database.SetInitializer<PonyContext>(new CreateDatabaseIfNotExists<PonyContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public Pony FindByID(string ID)
        {            
            return Ponies.Find(ID);
        }

        
    }

    class PonyContextInitializer : CreateAndMigrateDatabaseInitializer<PonyContext, Migrations.Configuration>
    {
        protected override void Seed(PonyContext context)
        {
            //context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX Name ON Stations (Name)");
            context.Ponies.AddOrUpdate(
                x => x.ID,
                new Pony { ID = 1, Name = "Flossy", Picture = "/media/ponies/flossy.png" },
                new Pony { ID = 2, Name = "Suri", Picture = "/media/ponies/suri.png" },
                new Pony { ID = 3, Name = "Trixie", Picture = "/media/ponies/trixie.png" },
                new Pony { ID = 4, Name = "Doris", Picture = "/media/ponies/doris.jpg" },
                new Pony { ID = 5, Name = "Applejack", Picture = "/media/ponies/applejack.jpg" },
                new Pony { ID = 6, Name = "Helen", Picture = "/media/ponies/helen.jpg" });
        }
    }

    class CreateAndMigrateDatabaseInitializer<TContext, TConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
    where TContext : DbContext
    where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _configuration;
        public CreateAndMigrateDatabaseInitializer()
        {
            _configuration = new TConfiguration();
        }
        public CreateAndMigrateDatabaseInitializer(string connection)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");

            _configuration = new TConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connection)
            };
        }
        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context");

            var migrator = new DbMigrator(_configuration);
            migrator.Update();

            // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
            base.InitializeDatabase(context);
        }
        protected override void Seed(TContext context)
        {
        }
    }

}
