using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public int StoreId { get; set; }
        public string ApplicationUserId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string ProductDescription { get; set; }
        public Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
