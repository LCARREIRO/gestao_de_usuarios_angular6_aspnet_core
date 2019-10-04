using GestaoDeUsuario.Dominio.Entidades;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using GestaoDeUsuario.Infra.Contexto;

namespace GestaoDeUsuario.Infra
{
    public class Seed
    {
        public static void Initialize(EfDbContext contexto)
        {
            contexto.Database.EnsureCreated();

            // Look for any students.
            if (contexto.Usuarios.Any())
            {
                return;   // DB has been seeded
            }

            var sexos = new Sexo[]
            {
               new Sexo(){Descricao = "Feminino"},
               new Sexo(){Descricao = "Masculino"}
            };

            foreach (Sexo sexo in sexos)
            {
                contexto.Sexo.Add(sexo);
            }
            contexto.SaveChanges();

            var usuarios = new Usuario[]
            {
            new Usuario("Luciano", new DateTime(29/11/1982), 1) { Email = "luciano2911@gmail.com", Senha="123", Ativo = true },

            };
            foreach (Usuario usuario in usuarios)
            {
                contexto.Usuarios.Add(usuario);
            }
            contexto.SaveChanges();
        }
    }
}