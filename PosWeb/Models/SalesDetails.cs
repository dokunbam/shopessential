using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class SalesDetails
    {
        public int ID { get; set; }
        public int SalesOutputId { get; set; }
        public SalesOutput SalesOutput { get; set; }
        public ICollection<SalesOutput> Sales { get; set; }
    }
}
