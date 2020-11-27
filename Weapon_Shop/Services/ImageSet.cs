using Infastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Weapon_Shop.Services
{
    public class ImageSet : IImageSet
    {
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
