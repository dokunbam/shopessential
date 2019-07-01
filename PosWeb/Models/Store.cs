using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int SalesId { get; set; }
        public int SubStoreId { get; set; }
        public ICollection<Sale> Sale{ get; set; }
        public ICollection<SubStore> SubStores { get; set; }


    }
}
