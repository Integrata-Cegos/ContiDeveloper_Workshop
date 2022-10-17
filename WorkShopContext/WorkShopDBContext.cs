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


    public virtual DbSet<TomSoftware> TomsSoftware { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=workshop;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            this.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS TomsSoftware");
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
