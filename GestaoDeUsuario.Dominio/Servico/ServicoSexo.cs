using GestaoDeUsuario.Dominio.Entidades;
using GestaoDeUsuario.Dominio.Interfaces.Repositorio;
using GestaoDeUsuario.Dominio.Interfaces.Servico;
using GestaoDeUsuario.Dominio.Servico.ServicoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeUsuario.Dominio.Servico
{
    public class ServicoSexo : ServicoBase<Sexo>, IServicoSexo
    {
        private readonly ISexoRepositorio _sexoRepositorio;

        public ServicoSexo(ISexoRepositorio sexoRepositorio)
            : base(sexoRepositorio)
        {
            _sexoRepositorio = sexoRepositorio;
        }
    }
}
