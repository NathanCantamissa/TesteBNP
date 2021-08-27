using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBNP.Negocios.Entidades
{
    public class MovimentoManual
    {
        [Required(ErrorMessage = "Digite o mês")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite apenas números")]
        public string Mes { get; set; }

        [Required(ErrorMessage = "Digite o ano")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite apenas números")]
        public string Ano { get; set; }
        public int NumeroLancamento { get; set; }

        [Required(ErrorMessage = "Escolha o produto")]
        public string CodigoProduto { get; set; }

        [Required(ErrorMessage = "Escolha o cosif")]
        public string CodigoCosif { get; set; }

        [Required(ErrorMessage = "Digite um valor")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Dê uma descrição")]
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string CodigoUsuario { get; set; } = "TESTE";
        public Produto Produto { get; set; }        
    }
}
