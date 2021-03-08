using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoreInde.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreInde.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
             .HasOne(p => p.Skills)
             .WithMany(b => b.Employees)
             .HasForeignKey(p => p.SkillsId);
        }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }

    }
}
