﻿using Los_Pollos_Hermanos.Helpers.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Los_Pollos_Hermanos.Models
{
    public class LosPollosHermanosContext : IdentityDbContext<User,AppRole,int>
    {
        public LosPollosHermanosContext(DbContextOptions<LosPollosHermanosContext> options)
            : base(options)
        {

        }
        public  override DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasOne(pl => pl.User).WithMany(u => u.Menus).HasForeignKey(pl => pl.UserId);
            });
            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasOne(t => t.Menus).WithMany(pl => pl.Places).HasForeignKey(t => t.PlaceId);
            });
           
        }
    }
}
