using TesteBNP.Negocios.Enumeradores;

namespace TesteBNP.Negocios.Entidades
{
    public class ProdutoCosif
    {
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public string CodigoClassificacao { get; set; }
        public Status Status { get; set; }
    }
}
