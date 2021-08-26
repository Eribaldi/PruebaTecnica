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
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        public EquiposContext(DbContextOptions<EquiposContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, FechaCreacion = DateTime.Now, NombreEstado = "Activo" }, 
                new Estado { Id = 2, FechaCreacion = DateTime.Now, NombreEstado = "Cancelado" }, 
                new Estado { Id = 3, FechaCreacion = DateTime.Now, NombreEstado = "Agente Libre" });

            modelBuilder.Entity<Equipo>().Property(e => e.Pais).HasMaxLength(3);
        }
    }
}
