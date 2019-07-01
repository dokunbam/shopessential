using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string ApplicationUserId { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public ICollection <Sale> Sale { get; set; }
        //public Sale Sales { get; set; } //I want see transactions of each customer
    }
}
