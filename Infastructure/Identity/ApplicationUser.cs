using Infastructure.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new List<Order>();
            Comments = new List<Comment>();
        }
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
