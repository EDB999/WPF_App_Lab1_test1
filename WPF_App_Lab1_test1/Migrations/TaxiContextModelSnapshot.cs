﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WPF_App_Lab1_test1;

#nullable disable

namespace WPF_App_Lab1_test1.Migrations
{
    [DbContext(typeof(TaxiContext))]
    partial class TaxiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WPF_App_Lab1_test1.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_car");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdCar"));

                    b.Property<string>("Model")
                        .HasColumnType("character varying")
                        .HasColumnName("model");

                    b.Property<string>("Number")
                        .HasColumnType("character varying")
                        .HasColumnName("number");

                    b.HasKey("IdCar")
                        .HasName("Cars_pkey");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .HasColumnType("character varying")
                        .HasColumnName("patronymic");

                    b.Property<string>("Phone")
                        .HasColumnType("character varying")
                        .HasColumnName("phone");

                    b.Property<string>("Surname")
                        .HasColumnType("character varying")
                        .HasColumnName("surname");

                    b.HasKey("IdClient")
                        .HasName("Clients_pkey");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Driver", b =>
                {
                    b.Property<int>("IdDriver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id_driver");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("IdDriver"));

                    b.Property<int?>("IdCar")
                        .HasColumnType("integer")
                        .HasColumnName("id_car");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("PhoneDriver")
                        .HasColumnType("character varying")
                        .HasColumnName("phone_driver");

                    b.Property<string>("Rating")
                        .HasColumnType("character varying")
                        .HasColumnName("rating");

                    b.Property<string>("Surname")
                        .HasColumnType("character varying")
                        .HasColumnName("surname");

                    b.HasKey("IdDriver")
                        .HasName("Drivers_pkey");

                    b.HasIndex("IdCar");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("integer")
                        .HasColumnName("id_order");

                    b.Property<string>("Date")
                        .HasColumnType("character varying")
                        .HasColumnName("date");

                    b.Property<int?>("IdClient")
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    b.Property<int?>("IdDriver")
                        .HasColumnType("integer")
                        .HasColumnName("id_driver");

                    b.Property<string>("Price")
                        .HasColumnType("character varying")
                        .HasColumnName("price");

                    b.Property<string>("Time")
                        .HasColumnType("character varying")
                        .HasColumnName("time");

                    b.HasKey("IdOrder")
                        .HasName("Orders_pkey");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdDriver");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Driver", b =>
                {
                    b.HasOne("WPF_App_Lab1_test1.Car", "IdCarNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdCar")
                        .HasConstraintName("fkey_car");

                    b.Navigation("IdCarNavigation");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Order", b =>
                {
                    b.HasOne("WPF_App_Lab1_test1.Client", "IdClientNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdClient")
                        .HasConstraintName("fkey_client");

                    b.HasOne("WPF_App_Lab1_test1.Driver", "IdDriverNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdDriver")
                        .HasConstraintName("fkey_driver");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdDriverNavigation");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Car", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WPF_App_Lab1_test1.Driver", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
