using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HyggeGaming.Models;

public partial class HGDBContext : DbContext
{
    string connectionString = null;

    public HGDBContext()
    {
    }

    public HGDBContext(DbContextOptions<HGDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DevTeam> DevTeams { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql16.unoeuro.com;Initial Catalog=hygge_gaming_com_db_data;User ID=hygge_gaming_com;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__9E0E9F0F2F8E59EC");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.ZipCode).HasName("PK__City__2CC2CDB9908A7F33");

            entity.Property(e => e.ZipCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<DevTeam>(entity =>
        {
            entity.HasKey(e => e.DevTeamId).HasName("PK__DevTeam__F8CC44909E0C3052");

            entity.HasOne(d => d.Employee).WithMany(p => p.DevTeams).HasConstraintName("FK__DevTeam__Employe__571DF1D5");

            entity.HasOne(d => d.Game).WithMany(p => p.DevTeams).HasConstraintName("FK__DevTeam__Game_ID__5812160E");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__78113481E897A940");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.ZipCodeNavigation).WithMany(p => p.Employees).HasConstraintName("FK__Employee__ZipCod__4CA06362");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__093B1F8E46115C4D");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Game__Assignment__5441852A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49B626B1EBB");

            entity.HasOne(d => d.Employee).WithMany(p => p.Roles).HasConstraintName("FK__Role__Employee_I__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
