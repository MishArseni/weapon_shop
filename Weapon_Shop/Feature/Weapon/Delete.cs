using Infastructure.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Weapon_Shop.Feature.Weapon
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
            protected async override Task Handle(Command request, CancellationToken cancellationToken)
            {
                var weapon = await _context.Weapon.FindAsync(request.Id);
                _context.Weapon.Remove(weapon);
                _context.SaveChanges();
            }
        }
    }
}
