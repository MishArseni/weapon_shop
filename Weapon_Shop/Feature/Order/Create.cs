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
                Console.WriteLine("Hello");
            }
        }
    }
}
