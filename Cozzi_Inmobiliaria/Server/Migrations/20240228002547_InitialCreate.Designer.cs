﻿// <auto-generated />
using System;
using Cozzi_Inmobiliaria.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cozzi_Inmobiliaria.Server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240228002547_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Alquiler", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<long>("InmuebleId")
                        .HasColumnType("bigint");

                    b.Property<long>("InquilinoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InmuebleId");

                    b.HasIndex("InquilinoId");

                    b.ToTable("Alquileres");
                });

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Inmueble", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<long>("Baños")
                        .HasColumnType("bigint");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<long>("Garages")
                        .HasColumnType("bigint");

                    b.Property<long>("Habitaciones")
                        .HasColumnType("bigint");

                    b.Property<long>("MetrosCuadrados")
                        .HasColumnType("bigint");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Patios")
                        .HasColumnType("bigint");

                    b.Property<long>("Pisos")
                        .HasColumnType("bigint");

                    b.Property<string>("Propietario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Propio")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Inmuebles");
                });

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Inquilino", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CantidadHijos")
                        .HasColumnType("bigint");

                    b.Property<bool>("Conyuge")
                        .HasColumnType("bit");

                    b.Property<long>("CuitCuil")
                        .HasColumnType("bigint");

                    b.Property<long>("Documento")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneMascotas")
                        .HasColumnType("bit");

                    b.Property<bool>("TieneVehiculo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Alquiler", b =>
                {
                    b.HasOne("Cozzi_Inmobiliaria.Shared.Models.Inmueble", "Inmueble")
                        .WithMany("Alquileres")
                        .HasForeignKey("InmuebleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cozzi_Inmobiliaria.Shared.Models.Inquilino", "Inquilino")
                        .WithMany("Alquileres")
                        .HasForeignKey("InquilinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inmueble");

                    b.Navigation("Inquilino");
                });

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Inmueble", b =>
                {
                    b.Navigation("Alquileres");
                });

            modelBuilder.Entity("Cozzi_Inmobiliaria.Shared.Models.Inquilino", b =>
                {
                    b.Navigation("Alquileres");
                });
#pragma warning restore 612, 618
        }
    }
}
