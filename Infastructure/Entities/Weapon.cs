using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Entities
{
    public  class Weapon : IEntity
    {
        public Weapon()
        {
            OrderWeapons = new List<OrderWeapon>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public byte[] Avatar { get; set; }
        public Weapon_Feature Weapon_Feature { get; set; }
        public List<OrderWeapon> OrderWeapons { get; set; }
    }
}
