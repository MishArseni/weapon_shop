using Infastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Weapon_Feature> Features { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderWeapon>().HasKey(o => new { o.OrderId, o.WeaponId });
        }
    }
}
