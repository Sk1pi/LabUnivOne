using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSystem.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.HasIndex(e => e.Serialnumber, "equipment_serialnumber_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Dailyrate)
                .HasPrecision(10, 2)
                .HasColumnName("dailyrate");
            entity.Property(e => e.Modelname)
                .HasMaxLength(100)
                .HasColumnName("modelname");
            entity.Property(e => e.Serialnumber)
                .HasMaxLength(100)
                .HasColumnName("serialnumber");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Available'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Category).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("equipment_categoryid_fkey");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rentals_pkey");

            entity.ToTable("rentals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actualreturndate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actualreturndate");
            entity.Property(e => e.Equipmentid).HasColumnName("equipmentid");
            entity.Property(e => e.Fineamount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0.00")
                .HasColumnName("fineamount");
            entity.Property(e => e.Plannedreturndate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("plannedreturndate");
            entity.Property(e => e.Rentdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("rentdate");
            entity.Property(e => e.Totalcost)
                .HasPrecision(10, 2)
                .HasColumnName("totalcost");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.Equipmentid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rentals_equipmentid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("rentals_userid_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_roleid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
