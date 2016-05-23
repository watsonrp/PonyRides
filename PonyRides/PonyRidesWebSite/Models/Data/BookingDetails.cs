using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyRidesWebSite.Models.Data
{
    public class BookingDetails
    {
        public string PonyID { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
    }
}
