﻿// <auto-generated />
using GreenLeaves.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenLeaves.Infrastructure.Migrations
{
    [DbContext(typeof(GreenLeavesContext))]
    [Migration("20230117230239_GreenLeavesMigration")]
    partial class GreenLeavesMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenLeaves.Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.HasIndex("IdState");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCountry = 1,
                            IdState = 1,
                            Name = "Leticia"
                        },
                        new
                        {
                            Id = 2,
                            IdCountry = 1,
                            IdState = 2,
                            Name = "Medellín"
                        },
                        new
                        {
                            Id = 3,
                            IdCountry = 1,
                            IdState = 3,
                            Name = "Arauca"
                        },
                        new
                        {
                            Id = 4,
                            IdCountry = 1,
                            IdState = 4,
                            Name = "Barranquilla"
                        },
                        new
                        {
                            Id = 5,
                            IdCountry = 1,
                            IdState = 5,
                            Name = "Bogotá"
                        },
                        new
                        {
                            Id = 6,
                            IdCountry = 1,
                            IdState = 6,
                            Name = "Cartagena"
                        },
                        new
                        {
                            Id = 7,
                            IdCountry = 1,
                            IdState = 7,
                            Name = "Tunja"
                        },
                        new
                        {
                            Id = 8,
                            IdCountry = 1,
                            IdState = 8,
                            Name = "Manizales"
                        },
                        new
                        {
                            Id = 9,
                            IdCountry = 1,
                            IdState = 9,
                            Name = "Florencia"
                        },
                        new
                        {
                            Id = 10,
                            IdCountry = 1,
                            IdState = 10,
                            Name = "Yopal"
                        });
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityAndState")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int>("Telephone")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Colombia"
                        });
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.ToTable("State");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCountry = 1,
                            Name = "Amazonas"
                        },
                        new
                        {
                            Id = 2,
                            IdCountry = 1,
                            Name = "Antioquia"
                        },
                        new
                        {
                            Id = 3,
                            IdCountry = 1,
                            Name = "Arauca"
                        },
                        new
                        {
                            Id = 4,
                            IdCountry = 1,
                            Name = "Atlántico"
                        },
                        new
                        {
                            Id = 5,
                            IdCountry = 1,
                            Name = "Bogotá"
                        },
                        new
                        {
                            Id = 6,
                            IdCountry = 1,
                            Name = "Bolívar"
                        },
                        new
                        {
                            Id = 7,
                            IdCountry = 1,
                            Name = "Boyacá"
                        },
                        new
                        {
                            Id = 8,
                            IdCountry = 1,
                            Name = "Caldas"
                        },
                        new
                        {
                            Id = 9,
                            IdCountry = 1,
                            Name = "Caquetá"
                        },
                        new
                        {
                            Id = 10,
                            IdCountry = 1,
                            Name = "Casanare"
                        });
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.City", b =>
                {
                    b.HasOne("GreenLeaves.Domain.Models.Country", "Country")
                        .WithMany("cities")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreenLeaves.Domain.Models.State", "State")
                        .WithMany("cities")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.State", b =>
                {
                    b.HasOne("GreenLeaves.Domain.Models.Country", "Country")
                        .WithMany("states")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.Country", b =>
                {
                    b.Navigation("cities");

                    b.Navigation("states");
                });

            modelBuilder.Entity("GreenLeaves.Domain.Models.State", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}
