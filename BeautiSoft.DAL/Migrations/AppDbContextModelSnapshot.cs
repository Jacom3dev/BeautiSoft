﻿// <auto-generated />
using System;
using BeautiSoft.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeautiSoft.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cita", b =>
                {
                    b.Property<Guid>("CitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClienteDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lugar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CitaID");

                    b.HasIndex("ClienteDocumento");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cliente", b =>
                {
                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dirreccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TipoDocumentoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Documento");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.DetalleCita", b =>
                {
                    b.Property<Guid>("DetalleCitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CitaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DetalleCitaID");

                    b.HasIndex("CitaID");

                    b.HasIndex("ServicioID");

                    b.ToTable("DetalleCitas");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Login", b =>
                {
                    b.Property<string>("UsuarioID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreUsario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Servicio", b =>
                {
                    b.Property<Guid>("ServicioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Detalle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioID");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.TipoDocumento", b =>
                {
                    b.Property<Guid>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TiposDocumento");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cita", b =>
                {
                    b.HasOne("BeautiSoft.Models.Entidades.Cliente", null)
                        .WithMany("Citas")
                        .HasForeignKey("ClienteDocumento");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cliente", b =>
                {
                    b.HasOne("BeautiSoft.Models.Entidades.TipoDocumento", "TipoDocument")
                        .WithMany("Clientes")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocument");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.DetalleCita", b =>
                {
                    b.HasOne("BeautiSoft.Models.Entidades.Cita", null)
                        .WithMany("DetalleCitas")
                        .HasForeignKey("CitaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeautiSoft.Models.Entidades.Servicio", null)
                        .WithMany("DetalleCitas")
                        .HasForeignKey("ServicioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cita", b =>
                {
                    b.Navigation("DetalleCitas");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Cliente", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.Servicio", b =>
                {
                    b.Navigation("DetalleCitas");
                });

            modelBuilder.Entity("BeautiSoft.Models.Entidades.TipoDocumento", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
