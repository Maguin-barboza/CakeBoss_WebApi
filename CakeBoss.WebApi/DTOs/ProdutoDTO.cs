using System.Collections.Generic;

namespace CakeBoss.WebApi.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double PrUnit { get; set; }
        public string Observacao { get; set; }
        public double Multiplicador { get; set; }
        

        public IEnumerable<ImagemDTO> Imgens { get; set; }
        public IEnumerable<ProdutoKitDTO> ProdutosKits { get; set; }
    }
}