﻿using GestaoDeUsuario.Dominio.Entidades;
using GestaoDeUsuario.Dominio.Interfaces.Repositorio;
using GestaoDeUsuario.Infra.Contexto;

namespace GestaoDeUsuario.Infra.Repositorio
{
    public class SexoRepositorio : RepositorioBase<Sexo>, ISexoRepositorio
    {
        private readonly EfDbContext _efdbontext;

        public SexoRepositorio(EfDbContext efdbontext) 
            : base(efdbontext)
        {
            _efdbontext = efdbontext;
        }
    }
}
