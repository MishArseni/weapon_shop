using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Weapon_Feature
{
    public class FeatureController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private readonly IMediator _mediator;
        public FeatureController( AppIdentityDbContext context, IMediator mediator)
        {     
            _context = context;
            _mediator = mediator;
        }

        public ActionResult Index(int id)
        {
            Infastructure.Entities.Weapon weapon = _context.Weapon.Include(x => x.Weapon_Feature).FirstOrDefault(x => x.Id == id);
            return View(weapon.Weapon_Feature);
        }

        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Create.Command command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index","Weapon");
        }

    }
}
