using Infastructure.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Order
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class CommandHandler : AsyncRequestHandler<Command>
        {
            private readonly AppIdentityDbContext _context;
            public CommandHandler(AppIdentityDbContext context)
            {
                _context = context;
            }

            protected override async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.FindAsync(request.Id);
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}


