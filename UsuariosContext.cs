using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiTokens.Models;

namespace WebApiTokens.Data
{
    public class UsuariosContext:DbContext
    {
        public UsuariosContext() : base("name=cadenaCopy") { }
     

        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UsuariosContext>(null);
        }
    }
}