using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAllieviationFoundation.Models
{
    public class MonetaryDonations
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Donor { get; set; }

        public MonetaryDonations()
        {

        }
    }
}
