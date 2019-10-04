using GestaoDeUsuario.Dominio.Entidades;
using GestaoDeUsuario.Dominio.Interfaces.Repositorio;
using GestaoDeUsuario.Dominio.Interfaces.Servico;
using GestaoDeUsuario.Dominio.Servico.ServicoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeUsuario.Dominio.Servico
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ServicoUsuario(IUsuarioRepositorio usuarioRepositorio)
            : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
    }
}
