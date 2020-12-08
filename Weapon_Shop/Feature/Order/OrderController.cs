using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Weapon_Shop.Feature.Order
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AppIdentityDbContext _context;
        public OrderController(IMediator mediator, AppIdentityDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

       
        public async Task<IActionResult> Create(Create.Command command)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Authentication");
            }
            command.Value = HttpContext.Session.GetString("Cart");
            command.UseName = User.Identity.Name;
            await _mediator.Send(command);
            return RedirectToAction("Index","Order");
        }

        public ActionResult Index()
        {
            return View(_context.Orders.Include(o=>o.User).ToList());
        }

        public async Task<IActionResult> Delete(Delete.Command command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
