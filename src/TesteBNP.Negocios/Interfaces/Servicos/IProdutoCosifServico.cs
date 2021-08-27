using System;
using System.Collections.Generic;
using System.Text;
using TesteBNP.Negocios.Entidades;

namespace TesteBNP.Negocios.Interfaces.Servicos
{
    public interface IProdutoCosifServico
    {
        List<ProdutoCosif> ObterTodos();
    }
}
