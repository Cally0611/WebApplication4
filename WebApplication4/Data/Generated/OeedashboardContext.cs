using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data;

public partial class OeedashboardContext : DbContext
{
    public OeedashboardContext()
    {
    }

    public OeedashboardContext(DbContextOptions<OeedashboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllMachine> AllMachines { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<OeeDetailsAll> OeeDetailsAlls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name= OEEDashboardCon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllMachine>(entity =>
        {
            entity.HasOne(d => d.Machine).WithMany(p => p.AllMachines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllMachines_Machine");
        });

        modelBuilder.Entity<OeeDetailsAll>(entity =>
        {
            entity.Property(e => e.StopDownTime).HasComputedColumnSql("(datediff(second,[StopReasonStart],[StopReasonEnd]))", false);

            entity.HasOne(d => d.OeeMachineNavigation).WithMany(p => p.OeeDetailsAlls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OeeDetailsAll_Machine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
