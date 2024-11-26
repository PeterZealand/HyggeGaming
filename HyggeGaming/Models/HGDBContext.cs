using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HyggeGaming.Models;

public partial class HGDBContext : DbContext
{
    public HGDBContext()
    {

    }
    string? connectionString = null;
    public HGDBContext(DbContextOptions<HGDBContext> options, IConfiguration config)
        : base(options)
    {
        connectionString = config.GetConnectionString("MyConnection");
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DevTeam> DevTeams { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TeamManager> TeamManagers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__9E0E9F0F0B0B4067");

            entity.HasOne(d => d.Game).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Game___6A30C649");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.ZipCode).HasName("PK__City__2CC2CDB902AF5EA2");

            entity.Property(e => e.ZipCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<DevTeam>(entity =>
        {
            entity.HasKey(e => e.DevTeamId).HasName("PK__DevTeam__F8CC44901BA9D067");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__78113481D84DD938");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.DevTeam).WithMany(p => p.Employees).HasConstraintName("FK__Employee__DevTea__656C112C");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees).HasConstraintName("FK__Employee__Role_I__6477ECF3");

            entity.HasOne(d => d.ZipCodeNavigation).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__ZipCod__6383C8BA");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__093B1F8E322F54F1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49BCD1D40D0");
        });

        modelBuilder.Entity<TeamManager>(entity =>
        {
            entity.HasKey(e => e.TmId).HasName("PK__TeamMana__9751B460492891D5");

            entity.HasOne(d => d.DevTeam).WithMany(p => p.TeamManagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeamManag__DevTe__6D0D32F4");

            entity.HasOne(d => d.Game).WithMany(p => p.TeamManagers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TeamManag__Game___6E01572D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
