using AutoMapper;
using Infastructure.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Weapon_Feature
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
            public string Country { get; set; }
            public int Caliber { get; set; }
            public int Capacity { get; set; }
            public string Material { get; set; }
            public int Speed { get; set; }
            public int Weight { get; set; }
            public string Type { get; set; }
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
                Infastructure.Entities.Weapon weapon = _context.Weapon.FirstOrDefault(x=>x.Name == request.Name);
                Infastructure.Entities.Weapon_Feature weapon_Feature = _mapper.Map<Command, Infastructure.Entities.Weapon_Feature>(request);
                weapon_Feature.WeaponId = weapon.Id;
                _context.Features.Add(weapon_Feature);
                _context.SaveChanges();
            }
        }
    }
}
