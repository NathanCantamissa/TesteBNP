using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Enumeradores;
using TesteBNP.Negocios.Interfaces;
using TesteBNP.Negocios.Interfaces.Repositorio;

namespace TesteBNP.Dados.Repositorio
{
    public class ProdutoCosifRepositorio : Repositorio<ProdutoCosif>, IProdutoCosifRepositorio
    {
        public ProdutoCosifRepositorio(IConexao conexao) : base(conexao)
        {
            _conexao = conexao;
        }

        private readonly IConexao _conexao;

        public List<ProdutoCosif> ObterTodos()
        {
            List<ProdutoCosif> retorno = new List<ProdutoCosif>();
            

            using (var conn = _conexao.Abrir())
            {
                SqlCommand cmd = new SqlCommand("UP_BNP_CONSULTAR_PRODUTO_COSIF_TODOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProdutoCosif produtoCosif = new ProdutoCosif();
                    produtoCosif.CodigoCosif = reader["COD_COSIF"].ToString();
                    produtoCosif.CodigoProduto = reader["COD_PRODUTO"].ToString();
                    produtoCosif.CodigoClassificacao = reader["COD_CLASSIFICACAO"].ToString();
                    produtoCosif.Status = reader["STA_STATUS"].ToString() == "A" ? Status.ATIVO : Status.INATIVO;

                    retorno.Add(produtoCosif);
                }

                return retorno;
            }
        }
    }
}
