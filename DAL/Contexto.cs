using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using OtroRegistroConDetalle.Models;
using System.Threading.Tasks;

namespace OtroRegistroConDetalle.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/Pedidos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Suplidores>().HasData(

                new Suplidores() { suplidorId = 1, nombre = "Jose Carlos" },
                new Suplidores() { suplidorId = 2, nombre = "Carmen Maria" },
                new Suplidores() { suplidorId = 3, nombre = "Ana Patria" },
                new Suplidores() { suplidorId = 4, nombre = "Andres Jesus" }
           );

            modelBuilder.Entity<Productos>().HasData(

                new Productos() { productoId = 1, descripcion = "Arroz Jose Jose", costo = 20, inventario = 1000 },
                new Productos() { productoId = 2, descripcion = "Carne Molida", costo = 120.5f , inventario = 500.25f },
                new Productos() { productoId = 3, descripcion = "Manzanas rojas", costo = 50, inventario = 100},
                new Productos() { productoId = 4, descripcion = "Salami Induveca", costo = 400, inventario = 203}
           );
        }

    }
}
