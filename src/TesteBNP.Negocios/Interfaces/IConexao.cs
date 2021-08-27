using System;
using System.Data;
using System.Data.SqlClient;

namespace TesteBNP.Negocios.Interfaces
{
    public interface IConexao : IDisposable
    {
        SqlConnection Abrir();
        void Fechar();
    }
}
