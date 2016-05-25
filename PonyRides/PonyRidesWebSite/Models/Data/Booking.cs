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
        public string CustomerID { get; set; }
        public int PonyID { get; set; }
        public int Session { get; set; }
        public DateTime Day { get; set; }
    }
}
