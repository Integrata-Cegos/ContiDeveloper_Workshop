using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkShopContext.Models;

namespace WorkShopContext;

public partial class WorkShopDBContext : DbContext
{
    public WorkShopDBContext()
    {
    }

    public WorkShopDBContext(DbContextOptions<WorkShopDBContext> options)
        : base(options)
    {
    }


    public virtual DbSet<WorkShopItem> WorkShopItems { get; set; } = null!;
    public virtual DbSet<Spielekonsole> Spielekonsolen { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    public virtual void Commit()
    {
         base.SaveChanges();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
