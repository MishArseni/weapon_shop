using Infastructure.Identity;
using Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Entities
{
   public  class Comment : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationUser User { get; set; }
    }
}
