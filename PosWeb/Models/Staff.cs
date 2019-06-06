using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string StaffEmail { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        ICollection<Sale> Sales { get; set; } //I want to see the sales perform per staff

    }
}
