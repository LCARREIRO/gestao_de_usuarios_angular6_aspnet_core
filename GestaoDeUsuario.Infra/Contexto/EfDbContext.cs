using GestaoDeUsuario.Dominio.Entidades;
using GestaoDeUsuario.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeUsuario.Infra.Contexto
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sexo> Sexo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new SexoMap());
        }
    }
}
