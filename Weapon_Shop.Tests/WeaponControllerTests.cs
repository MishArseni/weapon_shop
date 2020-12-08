using Infastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Weapon_Shop.Feature.Cart;
using Xunit;

namespace Weapon_Shop.Tests
{
   public  class WeaponControllerTests
    {
        public AppIdentityDbContext _context;
        public WeaponControllerTests(AppIdentityDbContext context)
        {
            _context = context;
        }
        [Fact]
        public void IndexViewDataMessage()
        {
            CartController controller = new CartController(_context);

            ViewResult result = controller.Index() as ViewResult; // надо использовать Moq

            Assert.NotNull(result);
        }
    }
}
