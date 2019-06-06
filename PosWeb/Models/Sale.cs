using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int productId { get; set; }
        public string ProductName { get; set; }
        public int TransactionId { get; set; }
        public string StaffName { get; set; }
        public int QuantityPurchased { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        //public decimal TotalAmountDue { get; set; }
        //public decimal TotalAmountPaid { get; set; }
        //public decimal Balance { get; set; }
        public DateTime SalesDate  { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        ICollection<Product> Products { get; set; }
        ICollection<Customer> Customers { get; set; }
    }
}
