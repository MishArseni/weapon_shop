using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Weapon_Feature
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.Command, Infastructure.Entities.Weapon_Feature>();
        }
    }
}
