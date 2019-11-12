using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; } //Taula
        public DbSet<Usuario> Usuarios { get; set; } //Taula
        public DbSet<Apuesta> Apuestas { get; set; } //Taula
        public DbSet<Mercado> Mercados { get; set; } //Taula
        public DbSet<Evento> Eventos { get; set; } //Taula

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=placemybet2;Uid=root;Pwd=''; SslMode = none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "pepe@gmail.com", "Pepe", "Sanchez", 29, 0, false, "Abc123%"));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "anagarcia@gmail.com", "Ana", "Garcia", 33, 0, true, "aBc123%"));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, 1, "Bankia", 1234123412341234, 2000, "pepe@gmail.com"));
            modelBuilder.Entity<Evento>().HasData(new Evento(1, DateTime.Now, "Alicante", 0, "Sueca", 0));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, DateTime.Now, "Cáceres", 0, "Albaida", 0));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5F, 1.9F, 1.9F, 100, 100, 2));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2.5F, 1.9F, 1.9F, 100, 100, 2));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 2.5F, true, 1.9F, 25, 1, 2));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, 1.5F, false, 1.9F, 50, 1, 1));
            */
        }
    }
}

