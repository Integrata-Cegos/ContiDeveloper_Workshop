using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WorkShopContext.Models;

namespace WorkShopContext;

public partial class WorkShopContext : DbContext
{
    public WorkShopContext()
    {
    }

    public WorkShopContext(DbContextOptions<WorkShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TomSoftware> Cars { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=workshop;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
