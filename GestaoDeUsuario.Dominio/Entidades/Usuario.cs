using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeUsuario.Dominio.Entidades
{
    public class Usuario
    {

        protected Usuario()
        { }

        public Usuario(string nome, DateTime dataNascimento, int sexoId)
        {
            setNome(nome);
            setDataNascimento(dataNascimento);
            setSexo(sexoId);            
        }

        public int UsuarioId { get; set; }
        public string Nome { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public bool Ativo { get;  set; }
        public virtual Sexo Sexo { get;  set; }
        public int SexoId { get; set; }

        public void setNome(string nome)
        {
            Nome = nome;
        }

        public void setDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public void setSexo(int sexoId)
        {
            SexoId = sexoId;
        }        
    }
}
