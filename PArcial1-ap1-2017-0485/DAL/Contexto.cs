using Microsoft.EntityFrameworkCore;
using PArcial1_ap1_2017_0485.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PArcial1_ap1_2017_0485.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ciudades> Ciudades { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"Data Source=Data\Cuidades.db");
        }
    }
}
