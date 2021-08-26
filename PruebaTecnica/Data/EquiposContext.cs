using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Data
{
    public class EquiposContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MiBaseDeDatos.db");

        }


        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>().ToTable("Jugadore");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Equipo>().ToTable("Equipo");
            modelBuilder.Entity<Equipo>().Property(e => e.Pais).HasMaxLength(3);
        }

    }
}
