using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Entities
{
   public  class OrderWeapon
    {
        public Order Order { get; set; }
        public Weapon Weapon { get; set; }
        public int OrderId { get; set; }
        public int WeaponId { get; set; }
    }
}
