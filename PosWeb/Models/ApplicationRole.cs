using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosWeb.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() {}
        public ApplicationRole(string RoleName) : base(RoleName)
        {

        }
        public ApplicationRole(string RoleName, string description, DateTime created) : base(RoleName)
        {
            Description = description;
            Created = created;
        }
        public string Description { get; set; }
        public DateTime Created { get; set; }

    }
}
