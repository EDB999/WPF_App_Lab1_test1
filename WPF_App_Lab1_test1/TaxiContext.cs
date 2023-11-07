using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_App_Lab1_test1;

public partial class TaxiContext : DbContext
{
    public TaxiContext()
    {
    }

    public TaxiContext(DbContextOptions<TaxiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Taxi;Username=postgres;Password=401330");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdCar).HasName("Cars_pkey");

            entity.Property(e => e.IdCar)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_car");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.Number)
                .HasColumnType("character varying")
                .HasColumnName("number");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("Clients_pkey");

            entity.Property(e => e.IdClient)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_client");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.IdDriver).HasName("Drivers_pkey");

            entity.Property(e => e.IdDriver)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Id_driver");
            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PhoneDriver)
                .HasColumnType("character varying")
                .HasColumnName("phone_driver");
            entity.Property(e => e.Rating)
                .HasColumnType("character varying")
                .HasColumnName("rating");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.IdCar)
                .HasConstraintName("fkey_car");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("Orders_pkey");

            entity.Property(e => e.IdOrder)
                .ValueGeneratedNever()
                .HasColumnName("id_order");
            entity.Property(e => e.Date)
                .HasColumnType("character varying")
                .HasColumnName("date");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdDriver).HasColumnName("id_driver");
            entity.Property(e => e.Price)
                .HasColumnType("character varying")
                .HasColumnName("price");
            entity.Property(e => e.Time)
                .HasColumnType("character varying")
                .HasColumnName("time");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("fkey_client");

            entity.HasOne(d => d.IdDriverNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdDriver)
                .HasConstraintName("fkey_driver");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
