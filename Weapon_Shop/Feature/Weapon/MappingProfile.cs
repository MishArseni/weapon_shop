using AutoMapper;
using Infastructure.Entities;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Weapon_Shop.Feature.Weapon
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.Command, Infastructure.Entities.Weapon>()
                .ForMember("Avatar", opt => opt.MapFrom(c => SetImage(c.Avatar)));
        }
        public byte[] SetImage(IFormFile Avatar)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(Avatar.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)Avatar.Length);
                return imageData;
            }
        }
    }
}
