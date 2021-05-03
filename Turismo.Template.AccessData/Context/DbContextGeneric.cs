using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Turismo.Template.AccessData.Context
{
    public class DbContextGeneric : DbContext
    {
        public DbContextGeneric(DbContextOptions<DbContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NombreServidorBD; Database = Template ; Trusted_Connection = True; ");
        }
    }
}
