using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAllieviationFoundation.Models
{
    public class GoodsDonations
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfItems { get; set; }
        public string Catergory { get; set; }

        public GoodsDonations()
        {

        }
    }
}
