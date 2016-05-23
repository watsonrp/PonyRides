using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PonyRidesWebSite.Models.Data
{
    class PonyContext : DbContext  
    {
        public DbSet<Pony> Ponies { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public PonyContext() : base("PonyDB")
        {
            Database.SetInitializer<PonyContext>(new CreateDatabaseIfNotExists<PonyContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public Pony FindByID(string ID)
        {            
            return Ponies.Find(ID);
        }

        
    }

}
