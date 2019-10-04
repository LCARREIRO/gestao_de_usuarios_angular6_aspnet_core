using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace GestaoDeUsuario.Api.Dto
{
    public class UsuarioDTO : Notifiable, IValidatable
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public virtual SexoDTO Sexo { get; set; }
        public int SexoId { get; set; }

        public void AddSexoId()
        {
            SexoId = Sexo.SexoId;
        }

        public void Validate()
        {
            AddSexoId();
            AddNotifications(
                new Contract()
                .HasMaxLen(Nome, 200, "Nome", "O capo Nome deve conter no máximo 200 caracteres")
                .HasMinLen(Nome, 3, "Nome", "O campo Nome deve conter pelo menos 3 caracteres")                
                .IsNotNull(Sexo.SexoId, "SexoId", "Campo obrigatório")
                .IsNotNull(DataNascimento.ToShortDateString(), "DataNascimento", "Campo obrigatório")
                .IsEmail(Email, "Email", "E-mail inválido")                
            );
        }
    }
}
