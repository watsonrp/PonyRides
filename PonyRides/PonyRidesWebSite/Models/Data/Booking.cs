using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyRidesWebSite.Models.Data
{
    public class Booking
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int PonyID { get; set; }
        public DateTime Time { get; set; }
        public int Duration { get; set; }
    }
}
