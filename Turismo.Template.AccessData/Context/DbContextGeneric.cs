using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.AccessData.Context
{
    public class DbContextGeneric : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Roll> Roles { get; set; }
        public DbSet<MetodoPago> MetodosPagos { get; set; }
        public DbContextGeneric(DbContextOptions<DbContextGeneric> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost;database=MsUser;trusted_connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var r1 = new Roll() { RollId = 1, Nombre = "Administrador", Descripcion = "Administrador" };
            var r2 = new Roll() { RollId = 2, Nombre = "Empleado", Descripcion = "Empleado" };
            var r3 = new Roll() { RollId = 3, Nombre = "Cliente", Descripcion = "Cliente" };
            modelBuilder.Entity<Roll>().HasData(new Roll[] { r1, r2, r3 });
        }
    }
}
