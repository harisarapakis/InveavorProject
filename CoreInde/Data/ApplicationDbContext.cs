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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Skills>()
        //        .HasOne(b => b.Employees)
        //        .WithOne(i => i.Skills)
        //        .HasForeignKey<Employees>(b => b.SkillsId);
        //}
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }

    }
}
