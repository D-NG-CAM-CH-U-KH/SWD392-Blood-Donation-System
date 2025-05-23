﻿using Microsoft.EntityFrameworkCore;

namespace SWD392_BloodDonationSystem.DAL.Data.Entities;

public class AppDbContext : DbContext
{
    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    public AppDbContext() { }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<RoleEntity>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<RoleEntity>()
            .Property(r => r.Name)
            .HasMaxLength(50).IsRequired();
        modelBuilder.Entity<RoleEntity>()
            .HasData(
                new RoleEntity { Id = 1, Name = "Admin" },
                new RoleEntity { Id = 2, Name = "User" }
            );

        
        modelBuilder.Entity<AccountEntity>()
            .HasOne(a => a.RoleEntity)
            .WithMany()
            .HasForeignKey(a => a.RoleId);
    }
}