using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Common.Models
{
    public partial class AssignmentAIContext : DbContext
    {
        public AssignmentAIContext()
        {
        }

        public AssignmentAIContext(DbContextOptions<AssignmentAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCode).HasMaxLength(10);

                entity.Property(e => e.Gender).HasMaxLength(15);

                entity.Property(e => e.MobileNo).HasMaxLength(15);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
