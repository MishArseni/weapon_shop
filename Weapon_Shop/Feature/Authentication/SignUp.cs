using AutoMapper;
using Infastructure.Identity;
using Infastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Weapon_Shop.Feature.Authentication
{
    public class SignUp
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public string UserName { get; set; }
  
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;
            private readonly IEmailSender _emailSender;
            public Handler(SignInManager<ApplicationUser> signInManager, IMapper mapper, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _mapper = mapper;
                _emailSender = emailSender;
            }
            protected override async  Task Handle(Command request, CancellationToken cancellationToken)
            {
                ApplicationUser user = _mapper.Map<Command, ApplicationUser>(request);
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user, false);
                   //await _emailSender.SendEmailAsync(user.Email, "Регистрация нового пользователя", "Спасибо за регистрацию в веб-приложении Weapon_Shop");
                }

            }
        }
    }
}
