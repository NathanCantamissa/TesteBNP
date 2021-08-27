using TesteBNP.Negocios.Interfaces;
using TesteBNP.Negocios.Interfaces.Repositorio;

namespace TesteBNP.Dados.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity>
    {
        public Repositorio(IConexao conexao)
        {
            _conexao = conexao;
        }

        private IConexao _conexao;
        public void Dispose()
        {
            _conexao?.Dispose();
        }
    }
}
