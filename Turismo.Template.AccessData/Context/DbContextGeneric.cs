using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.AccessData.Context
{
    public class DbContextGeneric : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbContextGeneric(DbContextOptions<DbContextGeneric> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=PC-JCONDE;database=MsUser;trusted_connection=True;");
        }
    }
}
