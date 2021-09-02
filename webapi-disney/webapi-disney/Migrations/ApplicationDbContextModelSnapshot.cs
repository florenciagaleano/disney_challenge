﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIDisney.Data;

namespace webapi_disney.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("webapi_disney.Models.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("webapi_disney.Models.Personaje", b =>
                {
                    b.Property<int>("IdPersonaje")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("IdPersonaje");

                    b.ToTable("Personajes");
                });

            modelBuilder.Entity("webapi_disney.Models.Show", b =>
                {
                    b.Property<int>("IdShow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Calificacion")
                        .HasColumnType("real");

                    b.Property<DateTime>("Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroIdGenero")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonajeIdPersonaje")
                        .HasColumnType("int");

                    b.Property<int?>("ShowIdShow")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdShow");

                    b.HasIndex("GeneroIdGenero");

                    b.HasIndex("PersonajeIdPersonaje");

                    b.HasIndex("ShowIdShow");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("webapi_disney.Models.Show", b =>
                {
                    b.HasOne("webapi_disney.Models.Genero", "Genero")
                        .WithMany("ShowsAsociados")
                        .HasForeignKey("GeneroIdGenero");

                    b.HasOne("webapi_disney.Models.Personaje", null)
                        .WithMany("Filmografia")
                        .HasForeignKey("PersonajeIdPersonaje");

                    b.HasOne("webapi_disney.Models.Show", null)
                        .WithMany("Personajes")
                        .HasForeignKey("ShowIdShow");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("webapi_disney.Models.Genero", b =>
                {
                    b.Navigation("ShowsAsociados");
                });

            modelBuilder.Entity("webapi_disney.Models.Personaje", b =>
                {
                    b.Navigation("Filmografia");
                });

            modelBuilder.Entity("webapi_disney.Models.Show", b =>
                {
                    b.Navigation("Personajes");
                });
#pragma warning restore 612, 618
        }
    }
}
