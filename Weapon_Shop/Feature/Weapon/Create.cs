using AutoMapper;
using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Weapon
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public IFormFile  Avatar { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly AppIdentityDbContext _context;
            private readonly IMapper _mapper;

            public Handler(AppIdentityDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            protected override void Handle(Command request)
            {
                var weapon = _mapper.Map<Command, Infastructure.Entities.Weapon>(request);
                _context.Weapon.Add(weapon);
                _context.SaveChanges();
            }
        }
    }
}
