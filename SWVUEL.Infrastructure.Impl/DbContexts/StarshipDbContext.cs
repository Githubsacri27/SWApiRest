﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SWVUEL.Infrastructure.Contracts.Entities;
using SWVUEL.Infrastructure.Impl;

namespace SWVUEL.Infrastructure.Impl.DbContexts;

public partial class StarshipDbContext : DbContext
{
    public StarshipDbContext()
    {
    }

    public StarshipDbContext(DbContextOptions<StarshipDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Starship> Starships { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Starship>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}