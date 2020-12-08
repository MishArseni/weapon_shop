using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Weapon_Shop.Feature.Authentication
{
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationController(IMediator mediator, SignInManager<ApplicationUser> signInManager)
        {
            _mediator = mediator;
            _signInManager = signInManager;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
  
        public async Task<IActionResult> SignIn(SignIn.Command command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
  
        public async Task<IActionResult> SignUp(SignUp.Command command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
         
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
