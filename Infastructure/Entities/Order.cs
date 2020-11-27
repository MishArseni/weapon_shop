using Infastructure.Identity;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Entities
{
    public class Order : IEntity
    {
        public Order()
        {
            
            OrderWeapons = new List<OrderWeapon>();
        }
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime Date { get; set; }
      
        public int Price { get; set; }
        public int Count { get; set; }
        public List<OrderWeapon> OrderWeapons { get; set; }

    }
}
