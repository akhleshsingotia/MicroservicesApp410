﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AuthSevice.Database.Entities;

namespace AuthSevice.Database
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("UserRoles");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}