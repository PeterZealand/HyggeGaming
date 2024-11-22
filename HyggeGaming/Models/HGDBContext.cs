using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

public partial class HGDBContext : DbContext
{
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
        => optionsBuilder.UseSqlServer("Data Source=mssql16.unoeuro.com;Initial Catalog=hygge_gaming_com_db_data;User ID=hygge_gaming_com;Password=zEk62p5GBaydtArw93R4;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__9E0E9F0F6CF3B6C5");

            entity.HasOne(d => d.Game).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Game___6E01572D");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.ZipCode).HasName("PK__City__2CC2CDB9A2B8B85F");

            entity.Property(e => e.ZipCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<DevTeam>(entity =>
        {
            entity.HasKey(e => e.DevTeamId).HasName("PK__DevTeam__F8CC44901672D023");

            entity.HasOne(d => d.Employee).WithMany(p => p.DevTeams).HasConstraintName("FK__DevTeam__Employe__70DDC3D8");

            entity.HasOne(d => d.Game).WithMany(p => p.DevTeams).HasConstraintName("FK__DevTeam__Game_ID__71D1E811");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7811348137B0BDC9");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasConstraintName("FK__Employee__Role_I__693CA210");

            entity.HasOne(d => d.ZipCodeNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__ZipCod__68487DD7");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__093B1F8E2BD81E1B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49B52D94540");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
