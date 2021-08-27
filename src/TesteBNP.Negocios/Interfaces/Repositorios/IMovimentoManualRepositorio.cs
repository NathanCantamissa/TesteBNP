using System;
using System.Collections.Generic;
using System.Text;
using TesteBNP.Negocios.Entidades;

namespace TesteBNP.Negocios.Interfaces.Repositorio
{
    public interface IMovimentoManualRepositorio : IRepositorio<MovimentoManual>
    {
        void Inserir(MovimentoManual movimento);
        List<MovimentoManual> ObterTodos();
        List<MovimentoManual> ObterLancamentos(string mes, string ano);
    }
}
