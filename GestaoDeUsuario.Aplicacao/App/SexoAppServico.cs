using GestaoDeUsuario.Dominio.Interfaces.Servico;
using GestaoDeUsuario.Aplicacao.App.Base;
using GestaoDeUsuario.Aplicacao.Interfaces;
using GestaoDeUsuario.Dominio.Entidades;

namespace GestaoDeUsuario.Aplicacao.App
{
    public class SexoAppServico : AppServicoBase<Sexo>, ISexoAppServico
    {
        private readonly IServicoSexo _servicoSexo;

        public SexoAppServico(IServicoSexo servicoSexo)
            :base(servicoSexo)
        {
            _servicoSexo = servicoSexo;
        }
    }
}
