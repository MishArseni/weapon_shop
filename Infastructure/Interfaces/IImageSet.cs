using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Interfaces
{
    public interface IImageSet
    {
        public byte[] SetImage(IFormFile Avatar);
    }
}
