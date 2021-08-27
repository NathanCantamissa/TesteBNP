using System;
using System.Collections.Generic;
using TesteBNP.Negocios.Entidades;

namespace TesteBNP.Negocios.Interfaces.Servicos
{
    public interface IMovimentoManualServico : IDisposable
    {
        void Inserir(MovimentoManual movimento);
        List<MovimentoManual> ObterTodos();
        int ObterNumeroLancamento(string ano, string mes);
    }
}
