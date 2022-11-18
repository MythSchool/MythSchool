using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PFmyschool.Models;
using System;
using System.Data;

namespace PFmyschool.Context
{
    public class ApplicationDbContext :DbContext
    {
        //zññ
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Escuelas> Escuelas { get; set; }

        public DbSet<Localidad> Localidad { get; set; }

        public DbSet<Nivel> Nivel { get; set; }

        public DbSet<OfertasEdu> OfertasEdu { get; set; }

        public DbSet<Sostenimiento> Sostenimiento { get; set; }

        public DbSet<Ubicacion> Ubicacion { get; set; }

        internal object Query<T>(string v, object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, CommandType CommandType)
        {
            throw new NotImplementedException();
        }
    }
}
