using GestaoDeUsuario.Dominio.Interfaces.Servico;
using GestaoDeUsuario.Aplicacao.App.Base;
using GestaoDeUsuario.Aplicacao.Interfaces;
using GestaoDeUsuario.Dominio.Entidades;

namespace GestaoDeUsuario.Aplicacao.App
{
    public class UsuarioAppServico : AppServicoBase<Usuario>, IUsuarioAppServico
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioAppServico(IServicoUsuario servicoUsuario)
            :base(servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }
    }
}
