using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TesteBNP.Dados.Repositorio;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Enumeradores;
using TesteBNP.Negocios.Interfaces;
using TesteBNP.Negocios.Interfaces.Repositorio;

namespace TesteBNP.Dados.Repositorio
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(IConexao conexao) : base(conexao)
        {
            _conexao = conexao;
        }

        private readonly IConexao _conexao;

        public List<Produto> ObterTodos()
        {
            List<Produto> retorno = new List<Produto>();
            Produto produto = new Produto();

            using (var conn = _conexao.Abrir())
            {
                SqlCommand cmd = new SqlCommand("UP_BNP_CONSULTAR_PRODUTO_TODOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    produto = new Produto();
                    produto.CodProduto = reader["COD_PRODUTO"].ToString();
                    produto.DescricaoProduto = reader["DES_PRODUTO"].ToString();
                    produto.Status = reader["STA_STATUS"].ToString() == "A" ? Status.ATIVO : Status.INATIVO;

                    retorno.Add(produto);
                }
                return retorno;
            }

        }
    }
}
