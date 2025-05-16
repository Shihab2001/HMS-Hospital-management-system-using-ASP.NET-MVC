using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HMS.Models;

public partial class HmsContext : DbContext
{
    public HmsContext()
    {
    }

    public HmsContext(DbContextOptions<HmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DrugStore> DrugStores { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("server=ABIR-HASAN;database=hms;trusted_connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");

            entity.Property(e => e.Designation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.DutyTime)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("duty_time");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RegisteredId).HasColumnName("registered_id");
            entity.Property(e => e.Specialist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("specialist");
        });

        modelBuilder.Entity<DrugStore>(entity =>
        {
            entity.ToTable("drug_store");

            entity.Property(e => e.DGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("d_group");
            entity.Property(e => e.Expire)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("expire");
            entity.Property(e => e.InStock).HasColumnName("in_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patient");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CheckIn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("check_in");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ProblemState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("problem_state");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("staff");

            entity.Property(e => e.DutyOff)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duty_off");
            entity.Property(e => e.DutyOn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duty_on");
            entity.Property(e => e.DutyPlace)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duty_place");
            entity.Property(e => e.DutyStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duty_status");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("post");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
