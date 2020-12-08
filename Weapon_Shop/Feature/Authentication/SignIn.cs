using AutoMapper;
using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Authentication
{
    public class SignIn
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;

            public Handler(SignInManager<ApplicationUser> signInManager)
            {
                _signInManager = signInManager;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            }
        }
    }
}
