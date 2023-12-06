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

    public virtual DbSet<OeeCalculationAll> OeeCalculationAlls { get; set; }

    public virtual DbSet<OeeDetailsAll> OeeDetailsAlls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog= OEEDashboard;Integrated Security=True;TrustServerCertificate=True");
       => optionsBuilder.UseSqlServer("Name=OEEDashboardCon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllMachine>(entity =>
        {
            entity.HasOne(d => d.Machine).WithMany(p => p.AllMachines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllMachines_Machine");
        });

        modelBuilder.Entity<OeeCalculationAll>(entity =>
        {
            entity.HasKey(e => e.OeeCalculationId).HasName("PK_OeeCalculation_1");

            entity.ToTable("OeeCalculationAll", tb => tb.HasTrigger("TR_OeeCalculationAll"));

            entity.Property(e => e.Waste).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Machine).WithMany(p => p.OeeCalculationAlls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OeeCalculation_Machine");
        });

        modelBuilder.Entity<OeeDetailsAll>(entity =>
        {
            entity.ToTable("OeeDetailsAll", tb => tb.HasTrigger("TR_OeeDetailsAll"));

            entity.Property(e => e.StopDownTime).HasComputedColumnSql("(datediff(second,[StopReasonStart],[StopReasonEnd]))", false);

            entity.HasOne(d => d.OeeMachineNavigation).WithMany(p => p.OeeDetailsAlls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OeeDetailsAll_Machine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
