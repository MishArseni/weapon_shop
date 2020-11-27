using AutoMapper;
using Infastructure.Identity;

namespace Weapon_Shop.Feature.Authentication
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUp.Command, ApplicationUser>();
        }
    }
}
