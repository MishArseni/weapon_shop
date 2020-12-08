using AutoMapper;
using Infastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


namespace Weapon_Shop.Feature.Order
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Value { get; set; }
            public string UseName { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command>
        {
            private readonly AppIdentityDbContext _context;
            public Handler(AppIdentityDbContext context)
            {
                _context = context;
            }
            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                List<Infastructure.Entities.Weapon> weapons = new List<Infastructure.Entities.Weapon>();
                weapons = JsonSerializer.Deserialize<List<Infastructure.Entities.Weapon>>(request.Value);

                Infastructure.Entities.Order order = new Infastructure.Entities.Order 
                {
                    Date = DateTime.Now, Count = weapons.Count,
                    Price = weapons.Sum(x => x.Price),
                    User = _context.Users.FirstOrDefault(x => x.UserName == request.UseName) 
                };

                await _context.Orders.AddAsync(order);
                _context.SaveChanges();

                foreach(var weapon in weapons)
                {
                    await _context.AddAsync(new Infastructure.Entities.OrderWeapon { OrderId = order.Id, WeaponId = weapon.Id });
                }

                _context.SaveChanges();
            }
        }
    }
}
