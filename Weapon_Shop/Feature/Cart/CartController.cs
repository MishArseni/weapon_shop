using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Cart
{
    public class CartController : Controller
    {
        private readonly AppIdentityDbContext _context;
        List<Infastructure.Entities.Weapon> weapons = new List<Infastructure.Entities.Weapon>();

        public CartController(AppIdentityDbContext context)
        {
            _context = context;
        }

        public ActionResult Add(int id)
        {
            weapons.Add(_context.Weapon.Find(id));

            if (HttpContext.Session.Keys.Contains("Cart"))
            {
                weapons.AddRange(JsonSerializer.Deserialize<List<Infastructure.Entities.Weapon>>(HttpContext.Session.GetString("Cart")));
            }

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<List<Infastructure.Entities.Weapon>>(weapons));
            return Content($"{HttpContext.Session.GetString("Cart")}");
        }

        public ActionResult Get()
        {
            weapons = JsonSerializer.Deserialize<List<Infastructure.Entities.Weapon>>(HttpContext.Session.GetString("Cart"));
            return View();
        }

        public ActionResult Delete(int id)
        {
            weapons = JsonSerializer.Deserialize<List<Infastructure.Entities.Weapon>>(HttpContext.Session.GetString("Cart"));
            Infastructure.Entities.Weapon weapon = _context.Weapon.Find(id);
            weapons.Remove(weapon);
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<List<Infastructure.Entities.Weapon>>(weapons));
            return RedirectToAction("Get");
        }
    }
}
