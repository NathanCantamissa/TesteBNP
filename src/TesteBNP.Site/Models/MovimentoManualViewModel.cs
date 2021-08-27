using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteBNP.Negocios.Entidades;

namespace TesteBNP.Site.Models
{
    public class MovimentoManualViewModel
    {
        public MovimentoManualViewModel()
        {
            MovimentoManual = new MovimentoManual();
        }

        public List<MovimentoManual> MovimentosManuais { get; set; }
        public List<ProdutoCosif> ProdutosCosif { get; set; }
        public List<Produto> Produtos { get; set; }

        [Required]
        public MovimentoManual MovimentoManual { get; set; }
    }
}