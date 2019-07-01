using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string StoreName { get; set; }
        public Sale Sales { get; set; }
    }
}
