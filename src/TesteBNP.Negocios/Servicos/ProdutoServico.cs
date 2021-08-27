using System;
using System.Collections.Generic;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Interfaces.Repositorio;
using TesteBNP.Negocios.Interfaces.Servicos;

namespace TesteBNP.Negocios.Servicos
{
    public class ProdutoServico : Servico, IProdutoServico
    {
        public ProdutoServico(IProdutoRepositorio rep)
        {
            _rep = rep;
        }

        private IProdutoRepositorio _rep;

        public List<Produto> ObterTodos()
        {
            return _rep.ObterTodos();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
