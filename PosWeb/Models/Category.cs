using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } //I  want to see list of products in each category
        public ICollection<Sale> Sales { get; set; } //I  want to see list of products in each category

    }
}
