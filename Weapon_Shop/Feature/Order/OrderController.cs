using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Weapon_Shop.Feature.Order
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Create(Create.Command command)
        {
            command.Value = HttpContext.Session.GetString("Cart");
            await _mediator.Send(command);
            return RedirectToAction("/");
        }
    }
}
