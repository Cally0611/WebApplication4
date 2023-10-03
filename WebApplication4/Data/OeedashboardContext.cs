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

    public virtual DbSet<Cleaning> Cleanings { get; set; }

    public virtual DbSet<DownTime> DownTimes { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MachineRepair> MachineRepairs { get; set; }

    public virtual DbSet<Machinestop> Machinestops { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<OeeCalculation> OeeCalculations { get; set; }

    public virtual DbSet<OeeDetailsAll> OeeDetailsAlls { get; set; }

    public virtual DbSet<Other> Others { get; set; }

    public virtual DbSet<Reasondetail> Reasondetails { get; set; }

    public virtual DbSet<StopReason> StopReasons { get; set; }

    public virtual DbSet<VwAllReason> VwAllReasons { get; set; }

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

        modelBuilder.Entity<Cleaning>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.Cleanings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cleaning_StopReasons");
        });

        modelBuilder.Entity<DownTime>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.DownTimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DownTime_StopReasons");
        });

        modelBuilder.Entity<MachineRepair>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.MachineRepairs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MachineRepair_StopReasons");
        });

        modelBuilder.Entity<Machinestop>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.Machinestops)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Machinestop_StopReasons");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material_StopReasons");
        });

        modelBuilder.Entity<OeeCalculation>(entity =>
        {
            entity.Property(e => e.ShiftDate).IsFixedLength();
        });

        modelBuilder.Entity<OeeDetailsAll>(entity =>
        {
            entity.Property(e => e.StopDownTime).HasComputedColumnSql("(datediff(second,[StopReasonStart],[StopReasonEnd]))", false);
        });

        modelBuilder.Entity<Other>(entity =>
        {
            entity.HasOne(d => d.StopReasonFkNavigation).WithMany(p => p.Others)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Other_StopReasons");
        });

        modelBuilder.Entity<Reasondetail>(entity =>
        {
            entity.HasKey(e => e.StopTimeId).HasName("PK_StopReasondetails");

            entity.Property(e => e.WorkerId).IsFixedLength();
        });

        modelBuilder.Entity<VwAllReason>(entity =>
        {
            entity.ToView("Vw_AllReason");

            entity.Property(e => e.StopTimeId).ValueGeneratedOnAdd();
            entity.Property(e => e.WorkerId).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
