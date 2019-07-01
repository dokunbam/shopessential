﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class SubStore
    {
        public int Id { get; set; }
        public string SubStoreName { get; set; }
        public int StoreId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int StaffId { get; set; }
        public ICollection<Staff> Staffs { get; set; }

    }
}
