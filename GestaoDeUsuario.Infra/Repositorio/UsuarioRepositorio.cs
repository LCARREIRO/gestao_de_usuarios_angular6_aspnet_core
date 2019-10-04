using GestaoDeUsuario.Dominio.Entidades;
using GestaoDeUsuario.Dominio.Interfaces.Repositorio;
using GestaoDeUsuario.Infra.Contexto;

namespace GestaoDeUsuario.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        private readonly EfDbContext _efdbontext;

        public UsuarioRepositorio(EfDbContext efdbontext) 
            : base(efdbontext)
        {
            _efdbontext = efdbontext;
        }
    }
}
