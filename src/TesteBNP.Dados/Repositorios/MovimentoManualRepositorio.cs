using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Interfaces;
using TesteBNP.Negocios.Interfaces.Repositorio;

namespace TesteBNP.Dados.Repositorio
{
    public class MovimentoManualRepositorio : Repositorio<MovimentoManual>, IMovimentoManualRepositorio
    {
        public MovimentoManualRepositorio(IConexao conexao) : base (conexao)
        {
            _conexao = conexao;
        }

        private readonly IConexao _conexao;

        public void Inserir(MovimentoManual movimento)
        {
            using (var conn = _conexao.Abrir())
            {
                SqlCommand cmd = new SqlCommand("UP_BNP_INSERIR_MOVIMENTO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DAT_MES", Convert.ToInt32(movimento.Mes));
                cmd.Parameters.AddWithValue("@DAT_ANO", Convert.ToInt32(movimento.Ano));
                cmd.Parameters.AddWithValue("@NUM_LANCAMENTO", movimento.NumeroLancamento);
                cmd.Parameters.AddWithValue("@COD_PRODUTO", movimento.CodigoProduto);
                cmd.Parameters.AddWithValue("@COD_COSIF", movimento.CodigoCosif);
                cmd.Parameters.AddWithValue("@VAL_VALOR", Convert.ToDecimal(movimento.Valor));
                cmd.Parameters.AddWithValue("@DES_DESCRICAO", movimento.Descricao);
                cmd.Parameters.AddWithValue("@DAT_MOVIMENTO", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }        

        public List<MovimentoManual> ObterTodos()
        {
            List<MovimentoManual> retorno = new List<MovimentoManual>();

            using (var conn = _conexao.Abrir())
            {
                SqlCommand cmd = new SqlCommand("UP_BNP_CONSULTAR_MOVIMENTO_TODOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MovimentoManual movimentoManual = new MovimentoManual();
                    movimentoManual.Mes = reader["DAT_MES"].ToString();
                    movimentoManual.Ano = reader["DAT_ANO"].ToString();
                    movimentoManual.NumeroLancamento = Convert.ToInt32(reader["NUM_LANCAMENTO"]);
                    movimentoManual.Produto = new Produto();
                    movimentoManual.Produto.CodProduto = reader["COD_PRODUTO"].ToString();
                    movimentoManual.Produto.DescricaoProduto = reader["DESCRICAO_PRODUTO"].ToString();
                    movimentoManual.CodigoCosif = reader["COD_COSIF"].ToString();
                    movimentoManual.Valor = reader["VAL_VALOR"].ToString();
                    movimentoManual.Descricao = reader["DESCRICAO_MOVIMENTO"].ToString();
                    movimentoManual.Data = Convert.ToDateTime(reader["DAT_MOVIMENTO"]);
                    movimentoManual.CodigoUsuario = reader["COD_USUARIO"].ToString();

                    retorno.Add(movimentoManual);
                }
            }

            return retorno;
        }

        public List<MovimentoManual> ObterLancamentos(string mes, string ano)
        {
            List<MovimentoManual> retorno = new List<MovimentoManual>();

            string consulta = @"SELECT DAT_MES, DAT_ANO, NUM_LANCAMENTO, COD_PRODUTO, COD_COSIF, VAL_VALOR, DES_DESCRICAO, COD_USUARIO 
                                FROM MOVIMENTO_MANUAL CC
                                WHERE CC.DAT_ANO = @DAT_ANO AND CC.DAT_MES = @DAT_MES 
                                AND CC.DAT_MOVIMENTO = (SELECT TOP 1 MAX(DAT_MOVIMENTO) FROM MOVIMENTO_MANUAL MM WHERE MM.DAT_ANO = CC.DAT_ANO AND MM.DAT_MES = CC.DAT_MES)
                                GROUP BY DAT_MES, DAT_ANO, NUM_LANCAMENTO, COD_PRODUTO, COD_COSIF, VAL_VALOR, DES_DESCRICAO, COD_USUARIO
                                ORDER BY NUM_LANCAMENTO DESC";

            using (var conn = _conexao.Abrir())
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@DAT_MES", Convert.ToInt32(mes));
                cmd.Parameters.AddWithValue("@DAT_ANO", Convert.ToInt32(ano));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MovimentoManual movimentoManual = new MovimentoManual();
                    movimentoManual.Mes = reader["DAT_MES"].ToString();
                    movimentoManual.Ano = reader["DAT_ANO"].ToString();
                    movimentoManual.NumeroLancamento = Convert.ToInt32(reader["NUM_LANCAMENTO"]);
                    movimentoManual.CodigoCosif = reader["COD_COSIF"].ToString();
                    movimentoManual.Valor = reader["VAL_VALOR"].ToString();
                    movimentoManual.Descricao = reader["DES_DESCRICAO"].ToString();
                    movimentoManual.CodigoUsuario = reader["COD_USUARIO"].ToString();

                    retorno.Add(movimentoManual);
                }
            }

            return retorno;
        }
    }
}
