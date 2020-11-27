using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Entities
{
   public  class Weapon_Feature : IEntity
    {
        public int Id { get; set; }
        public Weapon Weapon { get; set; }
        public int WeaponId { get; set; }
        public string Material { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public string Country { get; set; }
        public int Caliber { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
    }
}
