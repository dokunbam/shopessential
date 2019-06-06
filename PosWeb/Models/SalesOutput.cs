using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class SalesOutput
    {
        public int SalesOutputId { get; set; }
        //public int SaleId { get; set; }
        public int TransactionId { get; set; }
        public string CustomersName { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public decimal Balance { get; set; }
        public string TransactionStaff { get; set; }
        public DateTime SalesDate { get; set; }
        public Sale Sale { get; set; }
        public ICollection<Sale> Sales { get; set; }


    }
}
