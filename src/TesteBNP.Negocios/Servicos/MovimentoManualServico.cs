using System;
using System.Collections.Generic;
using System.Linq;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Interfaces.Repositorio;
using TesteBNP.Negocios.Interfaces.Servicos;

namespace TesteBNP.Negocios.Servicos
{
    public class MovimentoManualServico : Servico, IMovimentoManualServico
    {
        public MovimentoManualServico(IMovimentoManualRepositorio rep)
        {
            _rep = rep;
        }

        private IMovimentoManualRepositorio _rep;

        public void Inserir(MovimentoManual movimento)
        {
            movimento.NumeroLancamento = ObterNumeroLancamento(movimento.Ano, movimento.Mes);
            _rep.Inserir(movimento);
        }

        public List<MovimentoManual> ObterTodos()
        {
            return _rep.ObterTodos();
        }

        public int ObterNumeroLancamento(string ano, string mes)
        {
            List<MovimentoManual> x = _rep.ObterLancamentos(mes, ano);

            if (x.Count > 0)            
                return x.FirstOrDefault().NumeroLancamento + 1;            
            else            
                return 1;
            
        }

        public void Dispose()
        {
            _rep?.Dispose();
        }
    }
}
