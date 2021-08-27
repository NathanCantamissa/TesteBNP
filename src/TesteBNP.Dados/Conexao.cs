using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TesteBNP.Negocios.Interfaces;

namespace TesteBNP.Dados
{
    public class Conexao : IConexao
    {
        public Conexao(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        private SqlConnection SqlConnection;
        private IConfiguration _configuration;

        public SqlConnection Abrir()
        {
            try
            {
                SqlConnection = new SqlConnection(_configuration.GetConnectionString("Default"));

                if (!object.Equals(SqlConnection.State, ConnectionState.Open))
                    SqlConnection.Open();

                return SqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao conectar no banco de dados. {ex.Message}");
            }

        }

        public void Fechar()
        {
            try
            {
                if (!object.Equals(SqlConnection, null))                
                    if (object.Equals(SqlConnection.State, ConnectionState.Open))
                        SqlConnection?.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desconectar do banco de dados. {ex.Message}");
            }
        }

        public void Dispose()
        {
            Fechar();
        }
    }
}
