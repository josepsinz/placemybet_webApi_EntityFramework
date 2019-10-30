﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    [Migration("20191030111718_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAPI.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Apostado");

                    b.Property<float>("Cuota");

                    b.Property<int>("MercadoId");

                    b.Property<float>("TipoMercado");

                    b.Property<int>("UsuarioId");

                    b.Property<bool>("isOver");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");
                });

            modelBuilder.Entity("WebAPI.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Banco");

                    b.Property<string>("Email");

                    b.Property<long>("NumeroTarjeta");

                    b.Property<double>("Saldo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("CuentaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("WebAPI.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("GolesLocal");

                    b.Property<int>("GolesVisitante");

                    b.Property<string>("Local");

                    b.Property<string>("Visitante");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("WebAPI.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("CuotaOver");

                    b.Property<float>("CuotaUnder");

                    b.Property<double>("DineroOver");

                    b.Property<double>("DineroUnder");

                    b.Property<int>("EventoId");

                    b.Property<float>("TipoMercado");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");
                });

            modelBuilder.Entity("WebAPI.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Administrador");

                    b.Property<string>("Apellidos");

                    b.Property<int>("Edad");

                    b.Property<string>("Email");

                    b.Property<double>("Fondos");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAPI.Models.Apuesta", b =>
                {
                    b.HasOne("WebAPI.Models.Mercado", "Mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithMany("Apuestas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.Cuenta", b =>
                {
                    b.HasOne("WebAPI.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("WebAPI.Models.Cuenta", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebAPI.Models.Mercado", b =>
                {
                    b.HasOne("WebAPI.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
