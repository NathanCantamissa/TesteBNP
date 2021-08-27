using System;
using System.Collections.Generic;
using System.Text;
using TesteBNP.Negocios.Entidades;

namespace TesteBNP.Negocios.Interfaces.Repositorio
{
    public interface IProdutoCosifRepositorio
    {
        List<ProdutoCosif> ObterTodos();
    }
}
