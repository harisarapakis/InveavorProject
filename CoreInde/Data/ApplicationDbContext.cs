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
            .HasMany(p => p.Skills)
            .WithMany(p => p.Employees)
            .UsingEntity<EmpSkills>(
                j => j
                    .HasOne(pt => pt.Skills3)
                    .WithMany(t => t.EmpSkills)
                    .HasForeignKey(pt => pt.Skills3Id),
                j => j
                    .HasOne(pt => pt.Employees3)
                    .WithMany(p => p.EmpSkills)
                    .HasForeignKey(pt => pt.Employee3Id),
                j =>
                {
                    j.Property(pt => pt.EmpSkillDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.Employee3Id, t.Skills3Id });
                });
        }



        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<CoreInde.Models.EmpSkills> EmpSkills { get; set; }

        //public DbSet<EmpSkills> EmpSkills { get; set; }


    }
}
