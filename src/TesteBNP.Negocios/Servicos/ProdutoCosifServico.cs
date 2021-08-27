using System;
using System.Collections.Generic;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Interfaces.Repositorio;
using TesteBNP.Negocios.Interfaces.Servicos;

namespace TesteBNP.Negocios.Servicos
{
    public class ProdutoCosifServico : Servico, IProdutoCosifServico
    {
        public ProdutoCosifServico(IProdutoCosifRepositorio rep)
        {
            _rep = rep;
        }

        private IProdutoCosifRepositorio _rep;

        public List<ProdutoCosif> ObterTodos()
        {
            return _rep.ObterTodos();
        }
        public void Dispose()
        {
            
        }
    }
}
